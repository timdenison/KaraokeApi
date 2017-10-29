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

        [HttpPost]
        public void AddSongToSession([FromBody]Song userSong)
        {
            var highestOrderSong = _context.Songs.Where(s => s.SessionId == userSong.SessionId).OrderByDescending(s => s.Order).FirstOrDefault();
            var newSongOrder = 0;
            if(highestOrderSong != null){newSongOrder = highestOrderSong.Order + 1; }
            userSong.Order = newSongOrder;
            _context.Add(userSong);
            _context.SaveChanges();
        }
        
        [HttpDelete("{songId}")]
        public void DeleteSongFromSession(int songId)
        {
            var songToDelete = _context.Songs.Where(s => s.Id == songId).FirstOrDefault();
            _context.Remove(songToDelete);
            _context.SaveChanges();
        }
               
    }
}