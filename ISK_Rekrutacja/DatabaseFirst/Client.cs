using System;
using System.Collections.Generic;

namespace ISK_Rekrutacja.DatabaseFirst
{
    public partial class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
    }
}
