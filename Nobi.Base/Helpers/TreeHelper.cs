namespace Nobi.Base.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="TreeHelper" />.
    /// </summary>
    public static class TreeHelper
    {
        #region Methods

        public static IEnumerable<TreeItem<T>> GenerateTree<T, K>(
         this IEnumerable<T> collection,
         Func<T, K> id_selector,
         Func<T, K> parent_id_selector,
         K root_id = default(K))
        {
            foreach (var c in collection.Where(c => parent_id_selector(c).Equals(root_id)))
            {
                yield return new TreeItem<T>
                {
                    Item = c,
                    Children = collection.GenerateTree(id_selector, parent_id_selector, id_selector(c))
                };
            }
        }

        #endregion Methods
    }

    /// <summary>
    /// Defines the <see cref="TreeItem{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public class TreeItem<T>
    {
        #region Properties

        public IEnumerable<TreeItem<T>> Children { get; set; }

        public T Item { get; set; }

        #endregion Properties
    }
}