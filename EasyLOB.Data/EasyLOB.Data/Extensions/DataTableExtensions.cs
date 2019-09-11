using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace EasyLOB.Data
{
    /// <summary>
    /// DataTable Extensions.
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// Convert DataTable to IEnumerable.
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <returns>IEnumerable</returns>
        /// <remarks>
        /// How can I convert a DataTable into a Dynamic object ?
        /// https://stackoverflow.com/questions/7794818/how-can-i-convert-a-datatable-into-a-dynamic-object?utm_medium%3Dorganic%26utm_source%3Dgoogle_rich_qa%26utm_campaign%3Dgoogle_rich_qa
        /// System.Data.DataSetExtensions
        /// public static System.Data.EnumerableRowCollection[System.Data.DataRow] AsEnumerable (this System.Data.DataTable source)
        /// </remarks>
        public static IEnumerable<dynamic> AsEnumerable(this DataTable dataTable)
        {
            var dynamicDataTable = new List<dynamic>();

            foreach (DataRow row in dataTable.Rows)
            {
                dynamic dynamicObject = new ExpandoObject();
                dynamicDataTable.Add(dynamicObject);
                foreach (DataColumn column in dataTable.Columns)
                {
                    var dic = (IDictionary<string, object>)dynamicObject;
                    dic[column.ColumnName] = row[column];
                }
            }

            return dynamicDataTable;
        }

        /// <summary>
        /// Convert List to DataTable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        /// <remarks>
        /// Conversion Between DataTable and List in C#
        /// http://www.codeproject.com/Tips/784090/Conversion-Between-DataTable-and-List-in-Csharp
        /// References: System.Data.DataSetExtensions
        /// </remarks>
        public static DataTable ToDataTable<T>(this IList<T> list)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            const BindingFlags bindingFlags =
                BindingFlags.Instance | BindingFlags.Public;
            PropertyInfo[] propertyInfos = typeof(T).GetProperties(bindingFlags);

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                dataTable.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
            }

            foreach (T t in list)
            {
                var values = new object[propertyInfos.Length];
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    values[i] = propertyInfos[i].GetValue(t, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        /// <summary>
        /// Convert DataTable to List.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        /// <remarks>
        /// Conversion Between DataTable and List in C#
        /// http://www.codeproject.com/Tips/784090/Conversion-Between-DataTable-and-List-in-Csharp
        /// References: System.Data.DataSetExtensions
        /// </remarks>
        public static List<T> ToList<T>(this DataTable dataTable)
            where T : new()
        {
            var list = new List<T>();

            const BindingFlags bindingFlags =
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

            var objectFieldNames = (
                from PropertyInfo propertyInfo in typeof(T).GetProperties(bindingFlags)
                select new
                {
                    Name = propertyInfo.Name,
                    Type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType
                }
            ).ToList();

            var dataTableFieldNames = (
                from DataColumn aHeader in dataTable.Columns
                select new
                {
                    Name = aHeader.ColumnName,
                    Type = aHeader.DataType
                }
            ).ToList();

            var commonFields = objectFieldNames.Intersect(dataTableFieldNames).ToList();

            foreach (DataRow dataRow in dataTable.Rows)
            //foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
            {
                var t = new T();

                foreach (var aField in commonFields)
                {
                    PropertyInfo propertyInfos = t.GetType().GetProperty(aField.Name);
                    var value = (dataRow[aField.Name] == DBNull.Value) ? null : dataRow[aField.Name]; // database field is nullable
                    propertyInfos.SetValue(t, value, null);
                }

                list.Add(t);
            }

            return list;
        }
    }
}