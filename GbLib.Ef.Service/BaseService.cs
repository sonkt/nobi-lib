using GbLib.Ef.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

    public static class AppsettingsRegister
    {
        public static T AddAppSettings<T>(this IServiceCollection services, string sectionName = "AppSettingOptions") where T : class
        {
            IConfiguration requiredService = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            T val = (T)Activator.CreateInstance(typeof(T));
            requiredService.Bind(sectionName, val);
            services.AddSingleton(val);
            services.Configure<T>(requiredService.GetSection(sectionName));
            return val;
        }
    }
}