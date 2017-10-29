using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KaraokeApi.Models;
using System.Linq;


namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly KaraokeContext _context;

        public AuthorizationController(KaraokeContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Authorize([FromBody]AdminUser potentialAdminUser)
        {
            bool authorized = false;

            var test = _context.AdminUsers.ToList();
            
            if(_context.AdminUsers.Where(u => u.UserName == potentialAdminUser.UserName && u.Password == potentialAdminUser.Password).ToList().Count > 0){
                authorized = true;
            }
            
            return Ok(new {userIsAdmin =  authorized});
        }
        
               
    }
}