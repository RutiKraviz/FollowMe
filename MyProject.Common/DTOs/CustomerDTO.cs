using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.DTOs
{

    public class CustomerDTO : UserDTO
    {
        public int? StationId { get; set; }
    }
}

