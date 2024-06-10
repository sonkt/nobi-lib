using GbLib.Ef.Repositories;

namespace TestEf.Application
{
    public class TestEfRepository : Repository<TestEfEntity, Guid>, ITestEfRepository
    {
        public TestEfRepository(TestEfDbContext dbContext) : base(dbContext)
        {
        }
    }
}