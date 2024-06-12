using Microsoft.Data.SqlClient;
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
        T GetRepository<T>() where T : class;

        /// <summary>
        /// Cập nhật thay đổi từ Repo vào DB
        /// </summary>
        /// <returns>Số lượng State đã cập nhật vào DB</returns>
        int CommitChange();

        /// <summary>
        /// Trả về đối tượng transaction của Context
        /// </summary>
        /// <returns>IDbContextTransaction</returns>
        IDbContextTransaction GetDbTransaction();

        /// <summary>
        /// Thực thi truy vấn SQL Select
        /// </summary>
        /// <typeparam name="T">Kiểu giá trị trả về</typeparam>
        /// <param name="sql">Câu lệnh SQL</param>
        /// <returns>Danh sách dữ liệu theo kiểu T</returns>
        Task<List<T>> FromSql<T>(string sql) where T : class;

        /// <summary>
        /// Thực thi câu lệnh SQL (Insert, Delete, Update)
        /// </summary>
        /// <param name="sql">Câu lệnh Sql</param>
        /// <returns>Trả về là 1 giá trị số nguyên thể hiện số dòng bị tác động</returns>
        Task<int> FromNonQuerySql(string sql, CancellationToken cancellationToken =default);

        /// <summary>
        /// Thực thi Store procedure với các tham số truyền vào
        /// </summary>
        /// <typeparam name="T">Kiểu giá trị trả về</typeparam>
        /// <param name="sqlName">Danh sách tham số SqlParameter gồm Input và Output theo các kiểu giá trị phù hợp</param>
        /// <param name="sqlParameters"></param>
        /// <returns>Danh sách dữ liệu theo kiểu T, nếu có tham số Output thì lấy trong danh sách sqlParameter</returns>
        List<T> FromStoreProcedure<T>(string storeName, SqlParameter[] sqlParameters) where T : class;
    }
}