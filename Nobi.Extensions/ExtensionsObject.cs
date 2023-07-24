namespace Nobi.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Defines the <see cref="ExtensionsObject" />.
    /// </summary>
    public static class ExtensionsObject
    {
        #region Methods

        /// <summary>
        /// Hàm copy data của 2 đối tượng cùng kiểu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dest"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDest CloneData<TDest, TSource>(this TDest dest, TSource source)
        {
            try
            {
                var propsOfSource = source.GetType().GetProperties();
                Dictionary<string, object> sourceValues = new Dictionary<string, object>();
                foreach (var item in propsOfSource)
                {
                    sourceValues.Add(item.Name, item.GetValue(sourceValues));
                }
                var propsOfDes = dest.GetType().GetProperties();
                foreach (var prop in propsOfDes)
                {
                    var propName = prop.Name;
                    if (sourceValues.ContainsKey(propName))
                    {
                        prop.SetValue(dest, sourceValues[propName], null);
                    }
                }

                return dest;
            }
            catch (System.Exception)
            {
                return default(TDest);
            }
        }

        public static IEnumerable<T> ToEnumerable<T>(this T obj)
        {
            yield return obj;
        }

        public static string Underscore(this string value)
          => string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));

        public static string GetDeclaringName(this MethodBase methodBase, [CallerMemberName] string memberName = "")
        {
            return memberName;
        }

        #endregion Methods
    }
}