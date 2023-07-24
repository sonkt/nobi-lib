namespace Nobi.Extensions
{
    using System;
    using System.Linq;
    using System.Text.Json;

    /// <summary>
    /// Defines the <see cref="GenericTypeExtensions" />.
    /// </summary>
    public static class GenericTypeExtensions
    {
        #region Methods

        public static string GetGenericTypeName(this object @object)
        {
            return @object.GetType().GetGenericTypeName();
        }

        public static string GetGenericTypeName(this Type type)
        {
            var typeName = string.Empty;

            if (type.IsGenericType)
            {
                var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());
                typeName = $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
            }
            else
            {
                typeName = type.Name;
            }

            return typeName;
        }
        public static string ToJsonString<T>(this T value)
        {
            return value == null ? string.Empty : JsonSerializer.Serialize(value, JsonSerializerOptions.Default);
        }

        #endregion Methods
    }
}