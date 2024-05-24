﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public class CostumerDTO
    {
        //public int CoustemerCode { get; set; }
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? lastName { get; internal set; }
        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Email { get; set; }

        public int UserId { get; set; }
    }
}
