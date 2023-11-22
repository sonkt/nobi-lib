﻿using GbLib.Services;
using GbLib.Repositories;

namespace Test
{
    public class TestService : BaseService<TestEntity, Guid>,ITestService
    {
        public TestService(IDapperOrmRepository<TestEntity,Guid> repository) : base(repository)
        {
        }
    }
}
