using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.models.Database;
using api.models;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class feedbackController : ControllerBase
    {
        // GET: api/feedback
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Feedback> Get()
        {
            FeedbackDBObj readObject = new FeedbackDBObj();
            return readObject.GetAllFeedback();
        }

        // GET: api/feedback/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetFeedback")]
        public List<Feedback> Get(int id)
        {
            FeedbackDBObj readObject = new FeedbackDBObj();
            return readObject.GetAllFeedback(id);
        }

        // POST: api/feedback
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Feedback value)
        {
            FeedbackDBObj readObject = new FeedbackDBObj();
            readObject.PostFeedback(value);
            //Console.WriteLine("I made it to the controller " + value.ReviewMessage);
        }

        // PUT: api/feedback/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
