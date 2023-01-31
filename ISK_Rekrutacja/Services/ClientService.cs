using ISK_Rekrutacja.DAL;
using Microsoft.EntityFrameworkCore;

namespace ISK_Rekrutacja.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _dbContext;
        public ClientService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(Guid id)
        {
            try
            {
                var client = _dbContext.Clients.AsNoTracking().FirstOrDefault(x => x.Id == id);

                if (client is null)
                    throw new ArgumentNullException(nameof(client));

                _dbContext.Clients.Remove(client);
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Client> GetClients(string searchWord)
        {
            try
            {
                IEnumerable<Client> searchedResult;

                var clients = _dbContext.Clients.AsNoTracking().ToList();

                if(!string.IsNullOrEmpty(searchWord))
                {
                    searchedResult = clients.Where(x => x.FirstName.Contains(searchWord));

                    if (searchedResult.Any()) return searchedResult.ToList();

                    searchedResult = clients.Where(x => x.LastName.Contains(searchWord));

                    if (searchedResult.Any()) return searchedResult.ToList();
                }

                return clients;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
