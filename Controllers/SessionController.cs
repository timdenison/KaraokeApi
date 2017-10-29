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
        
        [HttpPost]
        public IActionResult CreateNewSessionIfNoneActive()
        {
            bool activeSessionExists = _context.Sessions.Where(s => s.IsActive).Count() > 0;
            if(activeSessionExists){
                int existingSessionId = _context.Sessions.Where(s => s.IsActive).OrderByDescending(s => s.KaraokeSessionId).Select(s => s.KaraokeSessionId).FirstOrDefault();
                return Ok(new {sessionId = existingSessionId});
            }
            else
            {
                try
                {
                    var newKaraokeSession = new KaraokeSession { IsActive = true,  SessionName = "Beaudry Karaoke Session"};
                    _context.Sessions.Add(newKaraokeSession);
                    _context.SaveChanges();

                    return Ok(new {sessionId = newKaraokeSession.KaraokeSessionId});
                }
                catch
                {
                    //placeholder for appropriate response
                    return Ok(new {sessionId = -1 });
                }
                
            }

        }
            
    }
}