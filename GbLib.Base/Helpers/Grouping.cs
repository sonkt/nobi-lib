namespace GbLib.Base.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="Grouping{S, T}" />.
    /// </summary>
    /// <typeparam name="S">.</typeparam>
    /// <typeparam name="T">.</typeparam>
    public class Grouping<S, T> : List<T>
    {
        #region Fields

        private readonly S _key;

        #endregion Fields

        #region Constructors

        public Grouping(IGrouping<S, T> group)
            : base(group)
        {
            _key = group.Key;
        }

        #endregion Constructors

        #region Properties

        public static List<T> All { private set; get; }

        public S Key
        {
            get { return _key; }
        }

        #endregion Properties
    }
}