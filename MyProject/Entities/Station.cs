using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public class Station
    {
        public int Id { get; set; }

        public string? Address { get; set; } 

        public int RouteId { get; set; }

    }
}
