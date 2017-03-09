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
    public class EventController : Controller
    {
        private TrainingContext TrainingContext;
        private RepositoryEvent RepoEvent;
        public EventController()
        {
            TrainingContext = new TrainingContext();
            RepoEvent = new RepositoryEvent(TrainingContext);

        }

        // GET: /api/
        [HttpGet ("getEvents")]
        public IEnumerable<Event> GetEvents()
        {
            return RepoEvent.GetAll().ToList();
        }

        [HttpPost("Add")]
        public Event AddEvent([FromBody]EventCredentialsDto value)
        {
                Event e = new Event();
                e.Name = value.Name;
                e.Date = value.Date;
                e.Price = value.Price;
                e.Location = value.Location;
                RepoEvent.Add(e);
                return e;
        }
        [HttpPost("Update")]
        public Event UpdateEvent([FromBody]EventCredentialsDto value)
        {
            Event e = new Event();
            e.IdEvent = value.IdEvent;
            e.Name = value.Name;
            e.Date = value.Date;
            e.Price = value.Price;
            e.Location = value.Location;
            RepoEvent.Update(e);
            return e;
        }
        [HttpPost("getbyid")]
        public Event GetById([FromBody]EventCredentialsDto value)
        {
            return RepoEvent.FindById(value.IdEvent);
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
