using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domen
{
    public class User
    {
        public int UserId { get; set; }
        public String Name { get; set; }
        //public List<Role> Roles { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
