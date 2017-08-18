using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KaraokeApi.Models;
using System.Linq;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class SongsController : Controller
    {
        private readonly KaraokeContext _context;

        public SongsController(KaraokeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Get()
        {

        }
        [HttpPost]
        public void AddSongToSession([FromBody]Song userSong)
        {
            _context.Add(userSong);
            _context.SaveChanges();
        }
        
               
    }
}