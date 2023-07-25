namespace GbLib.DapperOrm.Entities
{
    public interface IAuditEntity
    {
        #region Properties

        DateTime CreatedDate { get; set; }

        Guid CreatedUser { get; set; }

        DateTime? UpdatedDate { get; set; }

        Guid? UpdatedUser { get; set; }

        #endregion Properties
    }
    public interface IAuditEntity<TKey> : IAuditEntity, IDeleteEntity<TKey>
    {
    }
    public interface IDeleteEntity<TKey> : IDeleteEntity, IEntityBase<TKey>
    {
    }
}
