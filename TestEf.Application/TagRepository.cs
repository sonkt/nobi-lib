using GbLib.Ef.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEf.Application
{
    public class TagRepository : Repository<Tag, Guid>, ITagRepository
    {
        public TagRepository(TestEfDbContext dbContext) : base(dbContext)
        {
        }
    }
    public interface ITagRepository : IRepository<Tag, Guid> { }
}
