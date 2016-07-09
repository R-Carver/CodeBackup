﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PhysicalDocAddress
    {
        public int Id { get; set; }
        public string Room { get; set; }
        public string Address { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}