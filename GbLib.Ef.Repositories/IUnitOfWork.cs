using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace GbLib.Ef.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Trả về Repository theo Type truyền vào
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetRepository<T>() where T :class;
        /// <summary>
        /// Cập nhật thay đổi từ Repo vào DB
        /// </summary>
        /// <returns>Số lượng State đã cập nhật vào DB</returns>
        int CommitChange();

        IDbContextTransaction GetDbTransaction();
    }
}