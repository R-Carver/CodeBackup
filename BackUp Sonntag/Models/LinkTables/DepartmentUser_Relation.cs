﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DepartmentUser_Relation
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public int DepartmentID { get; set; }

        public virtual ContractUser User { get; set; }
        public virtual Department Department { get; set; }
    }
}