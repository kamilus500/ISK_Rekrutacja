using ISK_Rekrutacja.DAL;

namespace ISK_Rekrutacja
{
    public class Seeder
    {
        private readonly ApplicationDbContext _dbContext;
        public Seeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Clients.Any())
                {
                    var clients = new List<Client>()
                    {
                        new Client()
                        {
                            FirstName = "Kamil",
                            LastName = "Kurzeja",
                            Age = 23
                        },
                        new Client()
                        {
                            FirstName = "Anna",
                            LastName = "Kowalska",
                            Age = 50
                        }
                    };

                    _dbContext.Clients.AddRange(clients);
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
