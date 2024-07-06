using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public class Customer
    {
        //public int CustomerCode { get; set; }
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        public string? FullAddress { get; set; }

        public string? Email { get; set; }

        public int UserId { get; set; }
    }
}
