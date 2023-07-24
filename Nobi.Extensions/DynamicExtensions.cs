namespace Nobi.Extensions
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Dynamic;

    /// <summary>
    /// Defines the <see cref="DynamicExtensions" />.
    /// </summary>
    public static class DynamicExtensions
    {
        #region Methods

        public static dynamic ToDynamic(this object value)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
                expando.Add(property.Name, property.GetValue(value));

            return expando as ExpandoObject;
        }

        #endregion Methods
    }
}