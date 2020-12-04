using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.models.Database;
using api.models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        // GET: api/survey
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<User> Get()
        {
            UserDBObj readObject = new UserDBObj();
            return readObject.GetAllUsers();
        }

        // GET: api/survey/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetUsers")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/survey
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/survey/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
