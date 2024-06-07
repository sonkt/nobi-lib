using MicroOrm.Dapper.Repositories.Attributes.LogicalDelete;

namespace GbLib.Dapper.Entities
{
    public interface IDeleteEntity
    {
        #region Properties
        bool IsDeleted { get; set; }
        DateTime? DeletedDate { get; set; }
        Guid? DeletedUser { get; set; }

        #endregion Properties
    }
}