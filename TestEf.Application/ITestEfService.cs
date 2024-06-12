namespace TestEf.Application
{
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