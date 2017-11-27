using PT.Entity.IdentityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Entity.Model
{
    [Table("LaborLogs")]
    public class LaborLog:BaseModel
    {
        public DateTime StartShift { get; set; }
        public DateTime? EndShift { get; set; }//giriş saati boş olamaz
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
//giriş çıkış saati tutmak için bu class kullanılır
