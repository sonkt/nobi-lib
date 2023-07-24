namespace Nobi.Extensions
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ExtensionsTask" />.
    /// </summary>
    public static class ExtensionsTask
    {
        #region Methods

        public static async Task<TResult> FlatMap<T, TResult>(this Task<T> task, Func<T, Task<TResult>> fn) => await fn(await task);

        public static async Task ForEach<T>(this Task<T> task, Action<T> fn) => fn(await task);

        public static async Task<TResult> Map<T, TResult>(this Task<T> task, Func<T, TResult> fn) => fn(await task);

        #endregion Methods
    }
}