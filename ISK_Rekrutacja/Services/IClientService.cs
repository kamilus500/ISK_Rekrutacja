using ISK_Rekrutacja.DAL;

namespace ISK_Rekrutacja.Services
{
    public interface IClientService
    {
        public List<Client> GetClients(string searchWord = "");
        public void Delete(Guid id);
    }
}
