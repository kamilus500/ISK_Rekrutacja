using System.ComponentModel.DataAnnotations;

namespace ISK_Rekrutacja.DAL
{
    public class Client
    {
        public Guid Id { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
