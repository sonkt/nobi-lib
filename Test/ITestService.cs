using GbLib.Services;

namespace Test
{
    public interface ITestService : IBaseService<TestEntity, Guid>
    {
    }
}
