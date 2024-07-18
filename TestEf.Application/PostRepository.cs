using AutoMapper;
using GbLib.Ef.Repositories;

namespace TestEf.Application
{
    public class PostRepository : Repository<Post, Guid>, IPostRepository
    {
        public PostRepository(TestEfDbContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IPostRepository : IRepository<Post, Guid>
    { }
}