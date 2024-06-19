using GbLib.Ef.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace TestEf.Application
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _postRepository = _unitOfWork.GetRepository<PostRepository>();
        }

        public Task<bool> AddItemAsync(List<Post> items)
        {
            using (var trans = _unitOfWork.GetDbTransaction())
            {
                _postRepository.Insert(items);
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
        }

        public Task<List<Post>> GetAll()
        {
            return _postRepository.FindAllAsync();
        }
    }

    public interface IPostService
    {
        Task<bool> AddItemAsync(List<Post> items);

        Task<List<Post>> GetAll();
    }
}