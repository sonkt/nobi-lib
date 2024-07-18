namespace GbLib.Ef.Repositories
{
    public class Pagination<T>
    {
        #region Properties

        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }

        public IEnumerable<T> Items { set; get; }

        public int TotalCount { set; get; }

        #endregion Properties
    }
}