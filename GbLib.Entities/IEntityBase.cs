namespace GbLib.Entities
{
    public interface IEntityBase<TKey>
    {
        #region Properties

        TKey Id { get; set; }

        #endregion Properties
    }
}