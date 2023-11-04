using DotNetAPİDemo.Models;
using EF.Core.Repository.Interface.Repository;

namespace DotNetAPİDemo.Interfaces.Repository
{
    public interface IPostRepository : ICommonRepository<Post>
    {
    }
}