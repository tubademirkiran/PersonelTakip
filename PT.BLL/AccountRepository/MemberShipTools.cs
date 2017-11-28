using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PT.DAL;
using PT.Entity.IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.BLL.AccountRepository
{
    public class MemberShipTools
    {
        public static UserStore<ApplicationUser> NewUserStore() => new UserStore<ApplicationUser>(new MyContext());
        public static UserManager<ApplicationUser> NewUserManager() => new UserManager<ApplicationUser>(NewUserStore());
        public static RoleStore<ApplicationRole> NewRoleStore() => new RoleStore<ApplicationRole>(new MyContext());
        public static RoleManager<ApplicationRole> NewRoleManager() => new RoleManager<ApplicationRole>(NewRoleStore());
    }
}
//üyelik araçları
//identity ile ilgili işlemleri bu class dan yürütürüz, kullanıcı silme vb
