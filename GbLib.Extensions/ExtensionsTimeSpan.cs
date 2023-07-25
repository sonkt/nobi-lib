namespace GbLib.Extensions
{
    using System;

    /// <summary>
    /// Defines the <see cref="ExtensionsTimeSpan" />.
    /// </summary>
    public static class ExtensionsTimeSpan
    {
        #region Methods

        public static TimeSpan DivideBy(this TimeSpan span, double factor) => span.MultiplyBy(1 / factor);

        public static double DivideBy(this TimeSpan span, TimeSpan span2) => (double)span.Ticks / span2.Ticks;

        public static TimeSpan MultiplyBy(this TimeSpan span, double factor) => new TimeSpan((long)(span.Ticks * factor));

        #endregion Methods
    }
}