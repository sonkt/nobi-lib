using GbLib.Services;

namespace Test.Application
{
    public interface ITestService : IBaseService<TestEntity, Guid>
    {
    }
}
