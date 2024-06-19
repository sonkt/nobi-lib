using GbLib.Ef.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEf.Application
{
    public class PostRepository : Repository<Post, Guid>,IPostRepository
    {
        public PostRepository(TestEfDbContext dbContext) : base(dbContext)
        {
        }
    }
    public interface IPostRepository : IRepository<Post, Guid> { }
}
