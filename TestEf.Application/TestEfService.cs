using GbLib.Base.Helpers;
using GbLib.Ef.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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

        public Task<int> DeleteByIdAsync(Guid id)
        {

            return _unitOfWork.FromNonQuerySql($"DELETE FROM TestEfEntities WHERE PK_TestEfEntityID='{id}'");
        }

        public Task<List<TestEfEntity>> GetAll()
        {
            return _unitOfWork.FromSql<TestEfEntity>($"SELECT TOP 10 * FROM TestEfEntities ");
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

        public Task<PagedData> GetPagedAsync(int pageIndex, int pageSize)
        {
            var pNumber = new SqlParameter
            {
                Direction = System.Data.ParameterDirection.Input,
                Value = pageIndex,
                ParameterName = "pageIndex",
                DbType = System.Data.DbType.Int32
            };
            var pSize = new SqlParameter
            {
                Direction = System.Data.ParameterDirection.Input,
                Value = pageSize,
                ParameterName = "pageNumber",
                DbType = System.Data.DbType.Int32
            };
            var totalParam = new SqlParameter
            {
                Direction = System.Data.ParameterDirection.Output,
                Value = pageSize,
                ParameterName = "totalRow",
                DbType = System.Data.DbType.Int32
            };
            var arrParams = new SqlParameter[] { pNumber, pSize, totalParam };
            var result = _unitOfWork.FromStoreProcedure<TestEfEntity>("[dbo].[GetDataWithOutput]", arrParams);
            if (result != null)
            {
                var total = (int)totalParam.Value;
                var outPut = new PagedData
                {
                    Items = result,
                    TotalRows = total
                };
                return Task.FromResult(outPut);
            }
            return Task.FromResult(new PagedData
            {
                Items = new List<TestEfEntity> { },
                TotalRows = 0
            });
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

    public class PagedData
    {
        public List<TestEfEntity> Items { get; set; }
        public int TotalRows { get; set; }
    }
}