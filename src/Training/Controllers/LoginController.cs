using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.Repository;
using Training.Models;
using Training.Dtos;
using System.Net;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Training.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("login")]
        public ActionResult Login([FromBody]UserCredentialsDto value)
        {
            try
            {
                using (RepositoryUser repo = new RepositoryUser())
                {
                    if(repo.GetUser(value.Username, value.Password) != default(User))
                    {
                        return Ok();
                    }

                    return Unauthorized();
                }
            }catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
