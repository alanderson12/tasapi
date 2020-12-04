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
    public class rankingsController : ControllerBase
    {
        // GET: api/rankings
        [HttpGet]
        [EnableCors("AnotherPolicy")]
        public List<Rank> Get()
        {
            RankingDBObj readObject = new RankingDBObj();
            return readObject.GetAllRankings();
        }

        // GET: api/rankings/5
        [HttpGet("{id}", Name = "GetRankings")]
        [EnableCors("AnotherPolicy")]
        public List<Rank> Get(int id)
        {
            RankingDBObj readObject = new RankingDBObj();
            return readObject.GetAllRankings(id);
        }

        // POST: api/rankings
        [HttpPost]
        [EnableCors("AnotherPolicy")]
        public void Post([FromBody] Rank value)
        {
            RankingDBObj readObject = new RankingDBObj();
            readObject.PostRank(value);
        }

        // PUT: api/rankings/5
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
