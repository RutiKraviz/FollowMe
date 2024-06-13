using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public class CoustemerDTO
    {
        public int? Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; }= string.Empty;
        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int? UserId { get; set; }
    }
}
