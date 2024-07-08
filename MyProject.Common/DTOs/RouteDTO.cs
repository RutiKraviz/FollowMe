using MyProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public class RouteDTO
    {
        public int Id { get; set; }

        public string StartTime { get; set; }

        public List<StationDTO> Stations { get; set; }
    }
}
