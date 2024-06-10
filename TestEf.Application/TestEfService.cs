using GbLib.Ef.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TestEf.Application
{
    public class TestEfService : ITestEfService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TestEfService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<bool> AddItemAsync(TestEfEntity item)
        {
            var repo = _unitOfWork.GetRepository<TestEfRepository>();
            if (repo != null)
            {
                repo.Insert(item);
                var affected = _unitOfWork.CommitChange();
                return Task.FromResult(affected > 0);
            }
            return Task.FromResult(false);
        }

        public Task<bool> AddItemAsync(List<TestEfEntity> items)
        {
            using (var trans = _unitOfWork.GetDbTransaction())
            {
                var repo = _unitOfWork.GetRepository<TestEfRepository>();
                if (repo != null)
                {
                    repo.Insert(items);
                    var affected = _unitOfWork.CommitChange();
                    if (affected > 0)
                    {
                        trans.Commit();
                        return Task.FromResult(affected > 0);
                    }
                    else
                    {
                        trans.Rollback();
                        return Task.FromResult(false);
                    }
                }
                else
                {
                    trans.Rollback();
                    return Task.FromResult(false);
                }
            }
        }

        public async Task<TestEfEntity?> GetByIdAsync(Guid Id)
        {
            var repo = _unitOfWork.GetRepository<TestEfRepository>();
            if (repo != null)
            {
                return await repo.FindAsync(Id);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateItemAsync(TestEfEntity item, Guid Id)
        {
            try
            {
                var repo = _unitOfWork.GetRepository<TestEfRepository>();
                if (repo != null)
                {
                    var itemInDb = await repo.FindAsync(Id);
                    if (itemInDb == null)
                    {
                        return false;
                    }

                    repo.Update(item);
                    var affected = _unitOfWork.CommitChange();
                    return affected > 0;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}