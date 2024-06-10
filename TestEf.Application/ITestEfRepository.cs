using GbLib.Ef.Repositories;

namespace TestEf.Application
{
    public interface ITestEfRepository : IRepository<TestEfEntity, Guid>
    {
    }
}