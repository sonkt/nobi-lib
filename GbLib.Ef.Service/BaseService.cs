using GbLib.Ef.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace GbLib.Ef.Service
{
    public abstract class BaseService(IUnitOfWork unitOfWork) : IBaseService
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }
        private IUnitOfWork _unitOfWork = unitOfWork;

        public IDbContextTransaction GetDbTransaction()
        {
            return _unitOfWork.GetDbTransaction();
        }
        public virtual int SaveChange()
        {
            return _unitOfWork.CommitChange();
        }
    }
    public interface IBaseService
    {
        IDbContextTransaction GetDbTransaction();
        int SaveChange();
    }
}