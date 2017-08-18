using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KaraokeApi.Models;
using System.Linq;



namespace KaraokeApi.Controllers
{
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private readonly KaraokeContext _context;
        private readonly int _karaokeSessionId;
        public SessionController(KaraokeContext context)
        {
            _context = context;

            bool activeSessionExists = _context.Sessions.Where(s => s.IsActive).Count() > 0;

            //we've got an active session. There should only one. In any case, set the most recent active session to current session
            if (activeSessionExists)
            {
                _karaokeSessionId = _context.Sessions.Where(s => s.IsActive == true).OrderByDescending(s => s.KaraokeSessionId).Select(s => s.KaraokeSessionId).Single();
            }
            else
            {
                //CreateNewSession("New Session");
                _karaokeSessionId = -1;
            }
            

        }

        [HttpGet]
        public IActionResult GetSession()
        {
            return Ok(new { sessionId = _karaokeSessionId });
        }
        
        [HttpPut]
        public int CreateNewSession(string sessionName)
        {
            try
            {
                var newKaraokeSession = new KaraokeSession { IsActive = true,  SessionName = sessionName};
                _context.Sessions.Add(newKaraokeSession);

                

                //go through and make sure all other sessions are deactivated?


                // var newSong1 = new Song { Url = "www.youtube.com/test", StageName = "Peaches", Title = "This Test Song", IsComplete = false };
                // var newSong2 = new Song { Url = "www.youtube.com/test2", StageName = "Cream", Title = "This Test Song2", IsComplete = false };
                // _context.Songs.Add(newSong1);
                // _context.Songs.Add(newSong2);

                // _context.SaveChanges();
                // newSong1.SessionId = newKaraokeSession.KaraokeSessionId;
                // _context.Songs.Update(newSong1);
                _context.SaveChanges();

                return newKaraokeSession.KaraokeSessionId;
                
            }
            catch
            {
                return -1;
            }
        }
            
    }
}