using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domen
{
    public class Permission
    {

        public Permission(int PermissionId,String name)
        {
            this.PermissionId = PermissionId;
            this.name = name;
           
        }
        public int PermissionId { get; set; }
        public String name { get; set; }


        
    }
}
