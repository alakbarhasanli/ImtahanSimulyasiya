﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Service:AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Technicians> technicians { get; set; }

    }
}
