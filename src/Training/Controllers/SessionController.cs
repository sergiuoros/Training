using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1;
using Training.Models;
using Training.Repository;
using Training.Dtos;
using System.Net;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Training.Controllers
{
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private TrainingContext TrainingContext;
        private RepositorySession RepoSession;
        public SessionController()
        {
            TrainingContext = new TrainingContext();
            RepoSession = new RepositorySession(TrainingContext);

        }

        // GET: /api/
        [HttpGet("getSessions")]
        public IEnumerable<Session> GetSessionss()
        {
            return RepoSession.GetAll();
        }
        [HttpPost("getSessionsForEvent")]
        public IEnumerable<Session> GetSessionsForEvent([FromBody]SessionCredentialsDto value)
        {
            return RepoSession.GetSessionsForEvent(value.IdEvent);
        }

        [HttpPost("Add")]
        public Session AddSession([FromBody]SessionCredentialsDto value)
        {

            Session s = new Session();
            s.IdEvent = value.IdEvent;
            s.Name = value.Name;
            s.Duration = value.Duration;
            s.Difficulty = value.Difficulty;
            s.Description = value.Description;
            RepoSession.Add(s);
            return s;
        }
        [HttpPost("Update")]
        public Session UpdateSession([FromBody]SessionCredentialsDto value)
        {
            return null;
        }
        [HttpPost("getbyid")]
        public Session GetById([FromBody]SessionCredentialsDto value)
        {
            return RepoSession.FindById(value.IdSession);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (TrainingContext != null)
            {
                TrainingContext.Dispose();
            }
        }
    }
}
