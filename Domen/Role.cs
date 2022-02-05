using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domen
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public List<RolePermission> RolePermissions { get; set; }

        //public List<Permission> Permissions { get; set; }


    }
}
