using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApiFusion.Data;


namespace webApiFusion.Controllers
{
 
    [ApiController]
    public class GetUserPermission : ControllerBase
    {
        private UserContext context=new UserContext();
        [HttpGet]
        [Route("api/[controller]/{userId}")]
        public IActionResult GetUserPer(int userId)
        {
           List<Role> roles = context.Role.ToList().FindAll(r => r.UserId == userId);
            List<Permission> permissions = context.Permissions.ToList().FindAll(r => r.Role.UserId == userId);
            List<Permission> p2 = new List<Permission>();
            for(int i = 0; i < permissions.Count; i++)
            {
                Permission p = new Permission(permissions[i].PermissionId, permissions[i].name, permissions[i].RoleId);
                p2.Add(p);
            }
            // Prethodna funkcija je uradjena zbog toga sto permission sadrzi role, a taj role sadrzi odredjenu listu permission-a.I prilikom prikaza 
            // datih permissiona, dolazi do beskonacne petlje, iz tog razloga konstruktorom u funkciji je izbacen Role, vec samo stoji RoleId
            return Ok(p2);
        }
    }
}
