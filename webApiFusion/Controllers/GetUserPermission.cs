using Domen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace webApiFusion.Controllers
{
 
    [ApiController]
    public class GetUserPermission : ControllerBase
    {
        private UserContext context=new UserContext();
        [HttpGet]
        [Route("api/[controller]/{userId}")]
        public IActionResult Get(int userId)
        {
            List<UserRole> urs = context.userRole.ToList().FindAll(ur => ur.UserId == userId);
            List<RolePermission> rps = new List<RolePermission>();
            for (int i = 0; i < urs.Count; i++)
            {
                List<RolePermission> rp1 = context.rolePermission.ToList().FindAll(rp => rp.RoleId == urs[i].RoleId);
                rps=rps.Concat(rp1).ToList();
            }
            List<Permission> per = new List<Permission>();
            for(int i = 0; i < rps.Count; i++)
            {
                per.Add(context.Permissions.Find(rps[i].PermissionId));
            }
            return Ok(per);
        }
    }
}
