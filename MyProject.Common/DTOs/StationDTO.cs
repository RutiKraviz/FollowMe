using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.DTOs
{
    public class StationDTO
    {
        public int Id { get; set; }

        public string FullAddress { get; set; }

        public int RouteId { get; set; }

        public string Lan { get; set; }

        public string Lat { get; set; }
    }
}
