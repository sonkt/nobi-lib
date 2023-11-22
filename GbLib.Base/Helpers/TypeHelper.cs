using System.Collections;
using System.Globalization;
using System.Reflection;

namespace GbLib.Base.Helpers
{
    public sealed class Converter<TFrom, TTo> : Converter
    {
        #region Fields

        private readonly Func<object, object> _Converter;

        #endregion Fields

        #region Constructors

        public Converter(Func<TFrom, TTo> converter)
            : base(typeof(TFrom).GUID, typeof(TTo).GUID)
        {
            _Converter = o =>
            {
                if (!(o is TFrom))
                {
                    throw new ArgumentException();
                }

                return converter.Invoke((TFrom)o);
            };
        }

        #endregion Constructors

        #region Methods

        public override object Convert(object obj)
        {
            return _Converter.Invoke(obj);
        }

        #endregion Methods
    }

    public static class TypeHelper
    {
        #region Methods

        public static T As<T>(this object obj)
        {
            return obj != null ? (T)obj : default;
        }

        public static object ConvertObjectToType(object value, string type)
        {
            Type convertType;

            try
            {
                convertType = Type.GetType(type, true, true);
            }
            catch
            {
                convertType = Type.GetType("System.Guid", false);
            }

            if (value.GetType().ToString() == "System.String")
            {
                switch (convertType.ToString())
                {
                    case "System.Guid":

                        return new Guid(Convert.ToString(value));

                    case "System.Int32":
                        return Convert.ToInt32(value);

                    case "System.Int64":
                        return Convert.ToInt64(value);
                }
            }

            return Convert.ChangeType(value, convertType);
        }

        public static object[] GetCustomAttributes(Type objectType, Type attributeType)
        {
            object[] myAttrOnType = objectType.GetCustomAttributes(attributeType, false);
            if (myAttrOnType.Length > 0)
            {
                return myAttrOnType;
            }

            return null;
        }

        public static DateTime GetDateTime(DateTime? dt, DateTime defaultValue)
        {
            return dt.HasValue && dt.Value > DateTime.MinValue ? dt.Value : defaultValue;
        }

        public static T GetDefaultValue<T>(object obj)
        {
            T ret = default;
            try
            {
                if (obj == null)
                {
                    ret = (T)(object)"NULL";
                }
                else if (obj.GetType() == typeof(Guid))
                {
                    obj.TryCast(out ret);
                }
                else if (obj != null)
                {
                    ret = obj.ToType<T>();
                }
            }
            catch { }
            return ret;
        }

        public static T GetValue<T>(object value)
        {
            T result = default;
            try
            {
                if (value == null)
                {
                    return default;
                }
                if (!typeof(T).IsEnum)
                {
                    Type t = typeof(T);

                    result = (T)Convert.ChangeType(value, Nullable.GetUnderlyingType(t) ?? t);
                }
                else
                {
                    if (value != null)
                    {
                        result = (T)Enum.ToObject(typeof(T), value);
                    }
                }
            }
            catch { }
            return result;
        }

        public static DateTime GetValue(object value, CultureInfo culOfValue)
        {
            DateTime result = default;
            try
            {
                DateTimeFormatInfo culOfValueDtfi = culOfValue.DateTimeFormat;
                DateTimeFormatInfo currentCultDtfi = new CultureInfo(CultureHelper.GetCurrentCulture()).DateTimeFormat;
                string str = Convert.ToDateTime(value, culOfValueDtfi).ToString(currentCultDtfi.ShortDatePattern);
                result = Convert.ToDateTime(str);
            }
            catch { }
            return result;
        }

        public static T GetValue<T>(this object obj, string propertyName)
        {
            PropertyInfo property = obj.GetType().GetProperty(propertyName);

            return property != null ? property.GetValue(obj, null).As<T>() : default;
        }

        public static bool HasMethod<T>(this T obj, string methodName) where T : class
        {
            MethodInfo method = obj.GetType().GetMethod(methodName);

            return method != null;
        }

        public static bool Is<T>(this object obj)
        {
            return obj is T;
        }

        public static bool IsNotNull(this object obj)
        {
            return !obj.IsNull();
        }

        public static bool IsNull(this object obj)
        {
            return obj == null || obj.Equals(DBNull.Value);
        }

        public static bool IsNumeric(this object obj)
        {
            Type type = obj.GetType();

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;

                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return Nullable.GetUnderlyingType(type).IsNumeric();
                    }
                    return false;

                default:
                    return false;
            }
        }

        public static bool IsTypeOf<T>(this object obj)
        {
            return obj.GetType() == typeof(T);
        }

        public static T ToClass<T>(this object instance) where T : class
        {
            if (instance != null && instance is T)
            {
                return instance as T;
            }

            return null;
        }

        public static T ToDifferentClassType<T>(this object obj) where T : class
        {
            var tmp = Activator.CreateInstance(typeof(T));

            foreach (FieldInfo fi in obj.GetType().GetFields())
            {
                try
                {
                    tmp.GetType().GetField(fi.Name).SetValue(tmp, fi.GetValue(obj));
                }
                catch
                {
                }
            }

            return (T)tmp;
        }

        public static List<T> ToGenericList<T>(this IList listObjects)
        {
            var convertedList = new List<T>(listObjects.Count);

            foreach (object listObject in listObjects)
            {
                convertedList.Add((T)listObject);
            }

            return convertedList;
        }

        public static T ToType<T>(this object instance)
        {
            return (T)Convert.ChangeType(instance, typeof(T));
        }

        public static bool TryCast<T>(this object value, out T result)
        {
            if (value is T)
            {
                result = (T)value;
                return true;
            }

            var from = value.GetType().GUID;
            var to = typeof(T).GUID;
            var converter = new Converter<object, T>(s => (T)s);
            if (converter != null)
            {
                result = (T)converter.Convert(value);
                return true;
            }

            result = default;
            return false;
        }

        public static int ValidInt(object expression)
        {
            int value = 0;

            if (expression != null)
            {
                try
                {
                    int.TryParse(expression.ToString(), out value);
                }
                catch
                {
                }
            }

            return value;
        }

        public static bool VerifyBool(object o)
        {
            return Convert.ToBoolean(o);
        }

        public static int VerifyInt32(object o)
        {
            return Convert.ToInt32(o);
        }

        public static Type GetItemTypeOfList(IList<object> myList)
        {
            if (myList == null || myList.Count == 0)
            {
                return null;
            }
            return myList[0].GetType();
        }

        #endregion Methods
    }
}