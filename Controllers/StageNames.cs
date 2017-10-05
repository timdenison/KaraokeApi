using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KaraokeApi.Models;
using System.Linq;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class StageNamesController : Controller
    {
        private readonly KaraokeContext _context;

        public StageNamesController(KaraokeContext context)
        {
            _context = context;
        }
        [HttpGet("{sessionId}")]
        public List<StageName> GetSessionStageNames(int sessionId)
        {
            return _context.StageNames.Where(s => s.SessionId == sessionId && s.IsActive == true).OrderBy(s => s.Name).ToList();
        }

        [HttpPut]
        public void AddStageNameToSession([FromBody]StageName stageName)
        {
            _context.StageNames.Add(stageName);
            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteStageNameFromSession([FromBody]StageName stageName)
        {
            var stageNameToDeactivate = _context.StageNames.Where(s => s.Id == stageName.Id).SingleOrDefault();
            stageNameToDeactivate.IsActive = false;
            _context.SaveChanges();

        }
               
    }
}