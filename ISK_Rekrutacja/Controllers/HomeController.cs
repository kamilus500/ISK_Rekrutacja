using ISK_Rekrutacja.DAL;
using ISK_Rekrutacja.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISK_Rekrutacja.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IExportService _exportService;
        private static List<Client> clients = new List<Client>();
        public HomeController(IClientService clientService, IExportService exportService)
        {
            _clientService = clientService;
            _exportService = exportService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowClients(string searchName)
        {
            if (string.IsNullOrEmpty(searchName))
                clients = _clientService.GetClients();
            else
                clients = _clientService.GetClients(searchName);

            return View(clients);
        }

        public IActionResult Delete(Guid clientId)
        {
            _clientService.Delete(clientId);

            return RedirectToAction("ShowClients");
        }

        [HttpPost]
        public IActionResult ExportToExcel()
        {
            string fileName = "ISK_DataReport.xlsx";

            if(clients.Any())
            {
                var exportBytes = _exportService.ExportToExcel(clients, fileName);
                return File(exportBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            else
            {
                ViewBag.NoData = "No data to export";
                return RedirectToAction("ShowClients");
            }
        }
    }
}