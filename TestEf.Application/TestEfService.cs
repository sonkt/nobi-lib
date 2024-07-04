using GbLib.Ef.Repositories;
using GbLib.Ef.Service;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TestEf.Application
{
    public class TestEfService : BaseService, ITestEfService
    {
        public TestEfService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public Task<bool> AddItemAsync(TestEfEntity item)
        {
            var repo = UnitOfWork.GetRepository<TestEfRepository>();
            if (repo != null)
            {
                repo.Insert(item);
                var affected = UnitOfWork.CommitChange();
                return Task.FromResult(affected > 0);
            }
            return Task.FromResult(false);
        }

        public Task<bool> AddItemAsync(List<TestEfEntity> items)
        {
            using (var trans = UnitOfWork.GetDbTransaction())
            {
                var repo = UnitOfWork.GetRepository<TestEfRepository>();
                if (repo != null)
                {
                    repo.Insert(items);
                    var affected = UnitOfWork.CommitChange();
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
            return UnitOfWork.FromNonQuerySql($"DELETE FROM TestEfEntities WHERE PK_TestEfEntityID='{id}'");
        }

        public Task<List<TestEfEntity>> GetAll()
        {
            return UnitOfWork.FromSql<TestEfEntity>($"SELECT TOP 10 * FROM TestEfEntities ");
        }

        public async Task<TestEfEntity?> GetByIdAsync(Guid Id)
        {
            var repo = UnitOfWork.GetRepository<TestEfRepository>();
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
            var result = UnitOfWork.FromStoreProcedure<TestEfEntity>("[dbo].[GetDataWithOutput]", arrParams);
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
                var repo = UnitOfWork.GetRepository<TestEfRepository>();
                if (repo != null)
                {
                    var itemInDb = await repo.FindAsync(Id);
                    if (itemInDb == null)
                    {
                        return false;
                    }

                    repo.Update(item);
                    var affected = UnitOfWork.CommitChange();
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

    public interface ITestEfService
    {
        Task<bool> AddItemAsync(TestEfEntity item);

        Task<bool> AddItemAsync(List<TestEfEntity> items);

        Task<bool> UpdateItemAsync(TestEfEntity item, Guid Id);

        Task<TestEfEntity?> GetByIdAsync(Guid Id);

        Task<List<TestEfEntity>> GetAll();

        Task<int> DeleteByIdAsync(Guid id);

        Task<PagedData> GetPagedAsync(int pageIndex, int pageSize);
    }
}