using GbLib.Ef.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace GbLib.Ef.Service
{
    public abstract class BaseService(IUnitOfWork unitOfWork)
    {
        protected IUnitOfWork _unitOfWork = unitOfWork;

        private IDbContextTransaction GetDbTransaction()
        {
            return _unitOfWork.GetDbTransaction();
        }
    }
}