using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KaraokeApi.Models;
using System.Linq;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class SetListController : Controller
    {
        private readonly KaraokeContext _context;

        public SetListController(KaraokeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void ChangeSongOrder([FromBody]IEnumerable<Song> songs)
        {
            foreach(var song in songs){
                Song thisSong = _context.Songs.Where(s => s.Id == song.Id).SingleOrDefault();
                thisSong.Order = song.Order;
            }
            _context.SaveChanges();

        }
               
    }
}