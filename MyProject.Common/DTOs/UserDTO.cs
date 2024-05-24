using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string? Email { get; set; }
        public int PassWord { get; set; }

        public string? Role { get; set; }
    }
}
