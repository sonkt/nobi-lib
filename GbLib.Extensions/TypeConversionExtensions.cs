namespace GbLib.Extensions
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Defines the <see cref="TypeConversionExtensions" />.
    /// </summary>
    public static class TypeConversionExtensions
    {
        #region Methods

        public static T ConvertTo<T>(this string input)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)converter.ConvertFromString(input);
            }
            catch (NotSupportedException)
            {
                return default(T);
            }
        }

        #endregion Methods
    }
}