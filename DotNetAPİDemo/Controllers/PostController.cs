using DotNetAPİDemo.Context;
using DotNetAPİDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetAPİDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public PostController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Add(Post post)
        {
            post.CreatedAt = System.DateTime.Now;
            _dbContext.Posts.Add(post);
            bool isSaved = _dbContext.SaveChanges() > 0;
            if (isSaved)
            {
                return Ok(post);
            }
            else
            {
                return BadRequest("Post not saved");
            }
        }

        [HttpGet]
        public List<Post> GetAll()
        {
            var posts = _dbContext.Posts.ToList();
            return posts;
        }

        [HttpGet("{id}")]
        public Post GetById(int id)
        {
            var post = _dbContext.Posts.Find(id);
            return post;
        }

        [HttpPut]
        public IActionResult UpdatePost(Post post)
        {
            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = _dbContext.Posts.Find(id);
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}