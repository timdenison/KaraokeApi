using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KaraokeApi.Models;
using System.Linq;
using System;

namespace KaraokeApi.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly KaraokeContext _context;

        public AdminController(KaraokeContext context)
        {
            _context = context;

        }

        [HttpGet("{karaokeSessionId}", Name = "GetSessionSongs")]
        public IEnumerable<Song> GetSessionSongs(int karaokeSessionId)
        {
            List<Song> sessionSongs = new List<Song>();

            sessionSongs = _context.Songs.Where(s => s.SessionId == karaokeSessionId).ToList();

            return sessionSongs;
        }


        [HttpPut("{id}", Name = "DeactivateSession")]
        public IActionResult DeactivateSession(int id)
        {
            var sessionToDeactivate = _context.Sessions.Where(s => s.KaraokeSessionId == id).Single();
            sessionToDeactivate.IsActive = false;
            _context.Sessions.Update(sessionToDeactivate);
            try{

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var test = e.InnerException;
            }

            return new NoContentResult();
        }


    }
}