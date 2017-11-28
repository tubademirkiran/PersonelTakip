using Microsoft.AspNet.Identity.EntityFramework;
using PT.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Entity.IdentityModel
{
    public class ApplicationUser:IdentityUser 
    {
        [StringLength(25)]
        public string Name { get; set; }
        public string Surname { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime RegisterDate { get; set; } = DateTime.Now; //kayıt olduğu tarih
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }
        public string ActivationCode { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; } //kullanıcını bir department i olur
        public virtual List<LaborLog> LaborLogs { get; set; } = new List<LaborLog>();
        public List<SalaryLog> SalaryLogs { get; set; } = new List<SalaryLog>();


    }
}
//IdentityUser zaten sistemde olan kullanıcıdır biz ek özellik yazdık