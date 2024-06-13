using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public class Route
    {
        public int Id { get; set; }

        public List<Station> Stations { get; set; }
    }
}
