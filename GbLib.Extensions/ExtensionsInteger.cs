namespace GbLib.Extensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="ExtensionsInteger" />.
    /// </summary>
    public static class ExtensionsInteger
    {
        #region Methods

        public static IEnumerable<int> GetIntegersTo(this int start, int end)
        {
            int increment = Math.Sign(end - start);
            yield return start;
            int current = start;
            while (current != end)
            {
                current += increment;
                yield return current;
            }
        }

        public static int GetNextOddNumber(this int number) => number % 2 == 0
                ? number + 1
                : number + 2;

        public static string ToTimeString(this int totaltime)
        {
            try
            {
                return ((double)totaltime).ToTimeString();
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion Methods
    }
}