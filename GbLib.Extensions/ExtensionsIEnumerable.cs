namespace GbLib.Extensions
{
    using GbLib.Extensions;
    using MoreLinq;
    using OfficeOpenXml;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Defines the <see cref="ExtensionsIEnumerable" />.
    /// </summary>
    public static class ExtensionsIEnumerable
    {
        #region Methods

        public static double Average<T>(this IEnumerable<T> list, Func<T, int, double> f) =>
            list.WeightedAverage(f, (element, index) => 1);

        public static double Deviation(this IEnumerable<double> list) => Math.Sqrt(list.Variance());

        public static double Deviation<T>(this IEnumerable<T> list, Func<T, double> f) => Math.Sqrt(list.Variance(f));

        public static double ExponentialAverage<T>(this IEnumerable<T> list, Func<T, int, double> f)
        {
            T[] array = list.ToArray();

            return array
                .WeightedAverage(f, (element, index) => Math.Exp(index - array.Length));
        }

        public static bool IsDescendantlySorted(this IEnumerable<double> list) => list
            .Reverse()
            .IsSorted();

        public static bool IsDescendantlySortedBy<T>(this IEnumerable<T> list, Func<T, double> f) => list
                .Select(f)
                .IsDescendantlySorted();

        public static bool IsSorted(this IEnumerable<double> list)
        {
            bool sorted = true;
            List<double> doubles = list
                .ToList();
            for (int index = 0; index < doubles.Count - 1; index++)
            {
                double previousValue = doubles[index];
                double nextValue = doubles[index + 1];
                sorted = nextValue >= previousValue;
                if (!sorted)
                    break;
            }

            return sorted;
        }

        public static bool IsSortedBy<T>(this IEnumerable<T> list, Func<T, double> f) => list
                .Select(f)
                .IsSorted();

        public static double MaxDistanceBy<T>(this IEnumerable<T> list, Func<T, T, double> distance)
        {
            List<T> elements = list.ToList();
            double result = elements
                .SelectMany((element, index) => elements
                  .Select(element2 => (element, element2))
                )
                .Max(pair => distance(pair.element, pair.element2));
            return result;
        }

        public static IEnumerable<(T element1, T element2)> MaxDistantElementsBy<T>(this IEnumerable<T> list, Func<T, T, double> distance)
        {
            List<T> elements = list.ToList();
            IExtremaEnumerable<(T element, T element2)> result = MoreLinq.MoreEnumerable.MaxBy(
                elements.SelectMany((element, index) => elements.Select(element2 => (element, element2))),
                pair => distance(pair.element, pair.element2));

            return result;
        }

        public static double Variance(this IEnumerable<double> list)
        {
            List<double> doubles = list.ToList();
            double average = doubles.Average();
            double variance = doubles
                .Sum(d => Math.Pow(d - average, 2));
            return variance;
        }

        public static double Variance<T>(this IEnumerable<T> list, Func<T, double> f)
        {
            List<double> doubles = list
                .Select(f.Invoke)
                .ToList();
            double average = doubles.Average();
            double variance = doubles
                .Sum(d => Math.Pow(d - average, 2));
            return variance;
        }

        public static double WeightedAverage<T>(this IEnumerable<T> list
            , Func<T, int, double> function
            , Func<T, int, double> weightFunction)
        {
            double sum = 0;
            double sumWeights = 0;
            list
                .ForEach((element, index) =>
                {
                    sum += function(element, index) * weightFunction(element, index);
                    sumWeights += weightFunction(element, index);
                });
            return sum.DivideBy(sumWeights);
        }

        // import Excel
        public static List<T> ExcelFileToList<T>(this ExcelImportRequest request)
        {
            try
            {
                if (request.WorkSheet > 0)
                {
                    request.WorkSheet -= 1;
                }
                else
                {
                    request.WorkSheet = 0;
                }

                using (var stream = new MemoryStream())
                {
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;
                    request.File.CopyTo(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        // Connect to work space
                        var workbook = package.Workbook;
                        var worksheet = workbook.Worksheets[request.WorkSheet];
                        var rowCount = worksheet.Dimension.End.Row;
                        var colCount = worksheet.Dimension.End.Column;

                        int lastDataRow = worksheet.Cells
                        .Where(c => c.Start.Row <= worksheet.Dimension.End.Row
                                    && c.Start.Column == 1  // chỉ lấy các ô trong cột đầu tiên
                                    && !string.IsNullOrEmpty(c.Text))
                        .Max(c => c.Start.Row);

                        int endRow = rowCount - request.PaddingBottom;
                        return ReadData<T>(worksheet, request.StartRow, lastDataRow, request.HeaderNames);
                    }
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        private static List<T> ReadData<T>(ExcelWorksheet worksheet, int startRow, int endRow, List<string> headerNames)
        {
            Type objectType = typeof(T);
            var properties = objectType.GetProperties().ToList();
            List<T> listAnyThing = new List<T>();
            for (int row = startRow; row <= endRow; row++)
            {
                List<MapDataConfig> values = new List<MapDataConfig>();
                for (int i = 1; i < headerNames.Count; i++)
                {
                    object value = worksheet.Cells[row, i + 1].Value;
                    values.Add(new MapDataConfig
                    {
                        ColumnName = headerNames[i],
                        Value = (value != null) ? value.ToString()?.Trim() : string.Empty
                    });
                }
                var item = CreateNewIntanceByProperties<T>(values, properties);
                listAnyThing.Add(item);
            }
            return listAnyThing;
        }

        private static T CreateNewIntanceByProperties<T>(List<MapDataConfig> data, List<PropertyInfo> properties)
        {
            try
            {
                var obj = (T)Activator.CreateInstance(typeof(T));
                foreach (var item in properties)
                {
                    string columnName = item.Name;
                    var cellValue = data.Where(x => x.ColumnName == columnName).FirstOrDefault();
                    if (cellValue != null)
                    {
                        if (string.IsNullOrEmpty(cellValue.Value))
                        {
                            continue;
                        }
                        if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            Type underlyingType = Nullable.GetUnderlyingType(item.PropertyType);
                            if (underlyingType == typeof(DateTime))
                            {
                                var dateTimeValue = cellValue.Value.ConvertStringToDateTime();
                                item.SetValue(obj, Convert.ChangeType(dateTimeValue, underlyingType));
                            }
                            else
                            {
                                object underlyingValue = Convert.ChangeType(cellValue.Value, underlyingType);
                                object convertedValue = Activator.CreateInstance(item.PropertyType, underlyingValue);
                                item.SetValue(obj, Convert.ChangeType(convertedValue, underlyingType));
                            }
                        }
                        else
                        {
                            if (item.PropertyType == typeof(DateTime))
                            {
                                var dateTimeValue = cellValue.Value.ConvertStringToDateTime();
                                item.SetValue(obj, Convert.ChangeType(dateTimeValue, item.PropertyType));
                            }
                            else
                            {
                                item.SetValue(obj, Convert.ChangeType(cellValue.Value, item.PropertyType));
                            }
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể tạo đối tượng " + typeof(T).Name + "Khi thực hiện function importExcel");
                throw;
            }
        }

        #endregion Methods
    }
}