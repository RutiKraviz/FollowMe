using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{


    public class Customer : User
    {
        public int? StationId { get; set; }
    }
}

