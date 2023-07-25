namespace GbLib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Defines the <see cref="ExtensionsDictionary" />.
/// </summary>
public static class ExtensionsDictionary
{
    #region Methods

    public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) => dictionary.ContainsKey(key)
            ? dictionary[key]
            : default;

    public static T? GetValueByKey<T>(this Dictionary<string, string> searchDic, string key)
    {
        try
        {
            key = key.Trim();
            if (string.IsNullOrEmpty(key)) return default(T);
            string value = searchDic.Keys.Contains(key) ? searchDic[key] : null;
            if (value == null)
            {
                return default(T);
            }
            else
            {
                value = value.Trim();
                if (typeof(T) == typeof(string))
                    return (T)Convert.ChangeType(value, typeof(T));
            }

            Type targetType = typeof(T?);
            Type underlyingType = Nullable.GetUnderlyingType(targetType);
            object result = underlyingType != null
                ? Convert.ChangeType(value, underlyingType)
                : null;

            // Cast the result to the nullable type
            object nullableResult = result != null
                ? Activator.CreateInstance(targetType, result)
                : null;

            return (T)nullableResult;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Can't convert key when search, error : " + ex.Message);
            throw;
        }
    }

    #endregion Methods
}