using DotNetAPİDemo.Context;
using DotNetAPİDemo.Interfaces.Manager;
using DotNetAPİDemo.Models;
using DotNetAPİDemo.Repository;
using EF.Core.Repository.Manager;

namespace DotNetAPİDemo.Manager
{
    public class PostManager : CommonManager<Post>, IPostManager

    {
        public PostManager(ApplicationDbContext _dbContext) : base(new PostRepository(_dbContext))
        {
        }

        public Post GetById(int id)
        {
            return GetFirstOrDefault(x => x.Id == id);
        }

        public ICollection<Post> GetAll(string title)
        {
            return Get(c => c.Title.ToLower() == title.ToLower());
        }


        public ICollection<Post> SearchPost(string text)
        {
            return Get(x => x.Title.ToLower().Contains(text.ToLower()) || x.Description.ToLower().Contains(text.ToLower()));
        }

        public ICollection<Post> GetPosts(int page, int pageSize)
        {
            return Get(x => x.Id > (page - 1) * pageSize && x.Id <= page * pageSize);
        }
    }
}