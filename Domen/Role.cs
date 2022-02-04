using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApiFusion.Data
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public User User { get; set; }

        public List<Permission> Permissions { get; set; }

        public int UserId { get; set; }
    }
}
