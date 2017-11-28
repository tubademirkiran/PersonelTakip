﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Entity.ViewModel
{
    public class MailModel
    {
        public string To { get; set; } //kime gidecek
        public List<string> ToList { get; set; } = new List<string>();
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Cc { get; set; } //açık
        public string Bcc { get; set; } //gizli
    }
}
