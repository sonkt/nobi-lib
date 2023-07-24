using System.Reflection;
using System.Xml;

namespace Nobi.Extensions
{
    public static class ExtensionXml
    {
        public static List<T> ReadXmlFile<T>(this string path, List<Column> headers)
        {
            try
            {
                Type objectType = typeof(T);
                var properties = objectType.GetProperties().ToList();
                List<T> listAnyThing = new List<T>();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                XmlNodeList driverList = xmlDoc.GetElementsByTagName("NGUOI_LX");
                foreach (XmlNode item in driverList)
                {
                    var dicStudentinfo = ReadChildrenNode(item, "HO_SO");
                    XmlNode document = item.SelectSingleNode("HO_SO");
                    var subDic = ReadChildrenNode(document);
                    foreach (var tag in subDic)
                    {
                        dicStudentinfo.Add(tag.Key, tag.Value);
                    }
                    // Đến đây có 1 dictionary hoàn chỉnh và dữ liệu, list property
                    var _item = CreateObject<T>(dicStudentinfo, properties, headers);
                    listAnyThing.Add(_item);
                }
                var jsonModel = Newtonsoft.Json.JsonConvert.SerializeObject(listAnyThing);

                return listAnyThing;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR " + ex.Message);
                throw;
            }
        }
        public static Dictionary<string, string> ReadNode(this string path, string NodePath)
        {

            try
            {
                Dictionary<string, string> dicName = new Dictionary<string, string>();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                XmlNode node = xmlDoc.SelectSingleNode(NodePath);
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.NodeType == XmlNodeType.Element)
                    {
                        string childNodeName = childNode.Name;
                        string childNodeValue = childNode.InnerText;
                        dicName.Add(childNodeName, childNodeValue);
                    }
                }
                return dicName;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR " + ex.Message);
                throw;
            }
        }
        public static Dictionary<string, string> ReadChildrenNode(XmlNode xmlNode)
        {
            try
            {
                Dictionary<string, string> dicName = new Dictionary<string, string>();
                foreach (XmlNode childNode in xmlNode)
                {
                    if (childNode.NodeType == XmlNodeType.Element)
                    {
                        string childNodeName = childNode.Name;
                        string childNodeValue = childNode.InnerText;
                        dicName.Add(childNodeName, childNodeValue);
                    }
                }
                return dicName;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR " + ex.Message);
                throw;
            }
        }
        public static Dictionary<string, string> ReadChildrenNode(XmlNode xmlNode, string nodeName_non_read)
        {
            try
            {
                Dictionary<string, string> dicName = new Dictionary<string, string>();
                foreach (XmlNode childNode in xmlNode)
                {
                    if (childNode.NodeType == XmlNodeType.Element)
                    {
                        string childNodeName = childNode.Name;
                        string childNodeValue = childNode.InnerText;
                        if (!(childNodeName == nodeName_non_read))
                        {
                            dicName.Add(childNodeName, childNodeValue);
                        }
                    }
                }
                return dicName;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR " + ex.Message);
                throw;
            }
        }
        private static T CreateObject<T>(Dictionary<string, string> dicValue, List<PropertyInfo> properties, List<Column> configurationColumnName)
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            int n = 0;                            // step can be error 
            string columnError = string.Empty;    // column can be error

            try
            {
                foreach (var conf in configurationColumnName)
                {
                    var property = properties.FirstOrDefault(x => x.Name == conf.PropertyName);
                    var value = dicValue.FirstOrDefault(x => x.Key == conf.XmlName);
                    string temp = value.Value;

                    // next column 
                    if (temp == string.Empty || temp == null || temp == "|")
                    {
                        n++;
                        continue;
                    }

                    // if it's nullable then handle: 
                    if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        Type underlyingType = Nullable.GetUnderlyingType(property.PropertyType);
                        // it's datetime type
                        if (conf.IsDateTime == true)
                        {
                            // If it is too long, take 8 consecutive characters, 11 is the number of characters starting from an excess string
                            if (temp.Length > 11)
                            {
                                temp = temp.Substring(0, 8);
                            }
                            DateTime dateTime = temp.ParseDate();
                            property.SetValue(obj, Convert.ChangeType(dateTime, underlyingType));
                        }
                        else
                        {
                            object underlyingValue = Convert.ChangeType(temp, underlyingType);
                            object convertedValue = Activator.CreateInstance(property.PropertyType, underlyingValue);
                            property.SetValue(obj, Convert.ChangeType(convertedValue, underlyingType));
                        }
                    }
                    else
                    {
                        // If you need to execute data from outside.
                        if (conf.IsDataMismatch == true)
                        {
                            // while you need to execute data function
                            temp = conf.Func.HandleDataMismatch(temp);
                        }
                        // If it's a DateTimeType, convert it to the correct format.
                        if (conf.IsDateTime == true)
                        {
                            temp = value.Value;
                            DateTime date = DateTime.ParseExact(temp, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                            temp = date.ToString("MM/dd/yyyy");
                        }
                        property.SetValue(obj, Convert.ChangeType(temp, property.PropertyType));
                    }
                    columnError = conf.PropertyName;
                    n++;
                }
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cột không thể chuyển đổi dữ liệu : {columnError} và ở bước : " + n.ToString());
                throw;
            }
        }
    }
}
