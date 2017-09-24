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
        [HttpGet("{sessionId}")]
        public List<Song> GetSessionSongs(int sessionId)
        {
            return _context.Songs.Where(s => s.SessionId == sessionId).OrderBy(s => s.Order).ToList();
        }

        [HttpPut]
        public void AddSongToSession([FromBody]Song userSong)
        {
            _context.Add(userSong);
            _context.SaveChanges();
        }
        [HttpPost]
        public void ChangeSongOrder([FromBody]IEnumerable<Song> songs)
        {

        }
               
    }
}