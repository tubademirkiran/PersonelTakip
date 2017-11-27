﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Entity.IdentityModel
{
    public class ApplicationRole:IdentityRole
    {
        [StringLength(25)]
        public string Description { get; set; }
    }
}
//role tabanlı çalışmak için eklendi
