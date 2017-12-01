﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Entity.ViewModel
{
    public class UsersViewModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public DateTime RegisterDate { get; set; }

    }
    
}
