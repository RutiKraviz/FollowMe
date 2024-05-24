using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public int PassWord { get; set; }

        public string? Role { get; set; }
    }
}
