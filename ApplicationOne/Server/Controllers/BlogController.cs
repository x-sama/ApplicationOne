using ApplicationOne.Server.Data;
using ApplicationOne.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationOne.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {


        private readonly DataContext _Context;
        public BlogController(DataContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public ActionResult<List<Post>> GetAllBlogPosts()
        {
            return Ok(_Context.posts);
        }

        [HttpGet("{url}")]
        public ActionResult<Post> GetBlogPost(string url)
        {
            var post = _Context.posts.FirstOrDefault(p => p.URL.ToLower().Equals(url.ToLower()));
            if (post == null)
            {
                return NotFound("there is no post ");
            }

            return Ok(post);
        }

        [HttpPost]

        public async Task<ActionResult<Post>> PostBlogPost(Post post)
        {
            await _Context.posts.AddAsync(post);

            await _Context.SaveChangesAsync();

            return post;
        }
 
    }
}
