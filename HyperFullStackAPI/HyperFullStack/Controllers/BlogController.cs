using HyperFullStack.Models;
using HyperFullStack.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperFullStack.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
        public BlogController()
        {
            BlogPosts = BlogPostService.GetBlogPosts();
        }

        [HttpPost]
        public IActionResult Post([FromBody] BlogPost data)
        {
            BlogPosts.Add(data);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            BlogPosts = BlogPostService.GetBlogPosts();
            return Ok(BlogPosts);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] BlogPost data)
        {
            var item = BlogPosts.FirstOrDefault(x => x.Id == data.Id);
            item.Title = data.Title;
            item.Text = data.Text;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            BlogPosts.Remove(BlogPosts.FirstOrDefault(x => x.Id == id));
            return Ok();
        }

    }
}
