using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApiFusion.Data
{
    public class Permission
    {

        public Permission(int PermissionId,String name, int RoleId)
        {
            this.PermissionId = PermissionId;
            this.name = name;
            this.RoleId = RoleId;
        }
        public int PermissionId { get; set; }
        public String name { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }

        public override string ToString()
        {
            return "Permission id: "+ PermissionId+", Name: "+name+", Role id: "+RoleId;
        }
    }
}
