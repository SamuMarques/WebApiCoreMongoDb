using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebApiCoreWithMongoDb.Models;

namespace WebApiCoreWithMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private Context context;

        public PostController()
        {
            context = new Context();
        }
        // GET: api/Post
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            var posts = context.Posts.Find(x => true).ToList();
            return posts;
        }

        // GET: api/Post/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Post
        [HttpPost]
        public IActionResult Post([FromBody]Post value)
        {
            try
            {
                context.Posts.InsertOne(value);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                
            }
        }

        // PUT: api/Post/5
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
