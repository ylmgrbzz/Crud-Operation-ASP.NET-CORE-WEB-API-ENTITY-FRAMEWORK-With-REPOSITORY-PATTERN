using DotNetAPİDemo.Context;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DotNetAPİDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //private ApplicationDbContext _dbContext;
        private IPostManager _postManager


        public PostController(ApplicationDbContext dbContext)
        {
            //_dbContext = dbContext;
            _postManager = postManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var posts = _postManager.GetAll().OrderBy(c => c.CreatedAt).thenBy(c => c.Title).ToList();
                return CustomResult("data loaded succes", posts);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("title")]
        public IActionResult GetAll(string title)
        {
            try
            {
                var post = _postManager.GetAll(title);
                return CustomResult("data loaded succes", post.ToList());
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("text")]
        public IActionResult SearchPost(string text)
        {
            try
            {
                var posts = _postManager.SearchPost(text);
                return CustomResult("Searching result", posts);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public IActionResult getPosts(int page = 1)
        {
            try
            {
                var posts = _postManager.getPosts(page, 10);
                return CustomResult("Paging data for page no " + page, posts.ToList());
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public IActionResult GetAllDesc()
        {
            try
            {
                var posts = _postManager.GetAll().OrderByDescending(c => c.CreatedDate).ThenByDescending(c => c.Title).ToList();
                return CustomResult("Data loaded successfully.", posts);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var post = _postManager.GetById(id);
                if (post == null)
                {
                    return CustomResult("Data not found.", HttpStatusCode.NotFound);
                }
                return CustomResult("Data loaded successfully.", post);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}