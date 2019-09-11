using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace EasyLOB.Persistence
{
    /// <summary>
    /// DbDataReader Extensions.
    /// </summary>
    public static class DbDataReaderExtensions
    {
        #region DbDataReader

        /// <summary>
        /// Get column ordinal.
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>Column ordinal</returns>
        public static int GetColumnOrdinal(this DbDataReader reader, string columnName)
        {
            int result = -1;

            try
            {
                result = reader.GetOrdinal(columnName);
            }
            catch
            {
            }

            return result;
        }

        /// <summary>
        /// To Entity.
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="reader">Data Reader</param>
        /// <returns>Entity</returns>
        public static T ToEntity<T>(this DbDataReader reader)
        {
            T entity = (T)Activator.CreateInstance(typeof(T));

            List<string> properties = LibraryHelper.GetProperties(typeof(T));
            foreach (string property in properties)
            {
                int ordinal = reader.GetColumnOrdinal(property);
                if (ordinal >= 0)
                {
                    object value = reader.GetValue(ordinal);
                    if (!(value is DBNull))
                    {
                        LibraryHelper.SetPropertyValue(entity, property, value);
                    }
                }
            }

            return entity;
        }

        #endregion DbDataReader

        #region DbDataReader To... :: int index

        // Boolean

        /// <summary>
        /// Get DbDataReader column as bool.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static bool ToBoolean(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? LibraryDefaults.Default_Boolean : reader.GetBoolean(index);
        }

        /// <summary>
        /// Get DbDataReader column as bool nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static bool? ToBooleanNullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (bool?)null : reader.GetBoolean(index);
        }

        // Binary

        /// <summary>
        /// Get DbDataReader column as byte[].
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static byte[] ToBinary(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? new byte[] { } : (byte[])reader.GetValue(index);
        }

        /// <summary>
        /// Get DbDataReader column as byte[].
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static byte[] ToBinaryNullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (byte[])null : (byte[])reader.GetValue(index);
        }

        // Byte

        /// <summary>
        /// Get DbDataReader column as byte.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static byte ToByte(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? LibraryDefaults.Default_Byte : reader.GetByte(index);
        }

        /// <summary>
        /// Get DbDataReader column as byte nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static byte? ToByteNullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (byte?)null : reader.GetByte(index);
        }

        // DateTime

        /// <summary>
        /// Get DbDataReader column as DateTime.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? LibraryDefaults.Default_DateTime : reader.GetDateTime(index);
        }

        /// <summary>
        /// Get DbDataReader column as DateTime nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (DateTime?)null : reader.GetDateTime(index);
        }

        // Decimal

        /// <summary>
        /// Get DbDataReader column as decimal.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static decimal ToDecimal(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? LibraryDefaults.Default_Decimal : reader.GetDecimal(index);
        }

        /// <summary>
        /// Get DbDataReader column as decimal nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static decimal? ToDecimalNullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (decimal?)null : reader.GetDecimal(index);
        }

        // Double

        /// <summary>
        /// Get DbDataReader column as double.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static double ToDouble(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? LibraryDefaults.Default_Double : reader.GetDouble(index);
        }

        /// <summary>
        /// Get DbDataReader column as double nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static double? ToDoubleNullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (double?)null : reader.GetDouble(index);
        }

        // Guid

        /// <summary>
        /// Get DbDataReader column as Guid.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static Guid ToGuid(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? new Guid() : reader.GetGuid(index);
        }

        /// <summary>
        /// Get DbDataReader column as Guid nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static Guid? ToGuidNullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (Guid?)null : reader.GetGuid(index);
        }

        // Int16

        /// <summary>
        /// Get DbDataReader column as short.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static short ToInt16(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (short)LibraryDefaults.Default_Int16 : reader.GetInt16(index);
        }

        /// <summary>
        /// Get DbDataReader column as short nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static short? ToInt16Nullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (short?)null : reader.GetInt16(index);
        }

        // Int32

        /// <summary>
        /// Get DbDataReader column as int.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static int ToInt32(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (int)LibraryDefaults.Default_Int32 : reader.GetInt32(index);
        }

        /// <summary>
        /// Get DbDataReader column as int nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static int? ToInt32Nullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (int?)null : reader.GetInt32(index);
        }

        // Int64

        /// <summary>
        /// Get DbDataReader column as long.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static long ToInt64(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (long)LibraryDefaults.Default_Int64 : reader.GetInt64(index);
        }

        /// <summary>
        /// Get DbDataReader column as long nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static long? ToInt64Nullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (long?)null : reader.GetInt64(index);
        }

        // Single

        /// <summary>
        /// Get DbDataReader column as float.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static float ToSingle(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (float)LibraryDefaults.Default_Single : reader.GetFloat(index);
        }

        /// <summary>
        /// Get DbDataReader column as float nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static float? ToSingleNullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (float?)null : reader.GetFloat(index);
        }

        // String

        /// <summary>
        /// Get DbDataReader column as string.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static string ToString(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (string)LibraryDefaults.Default_String : reader.GetString(index).Trim();
        }

        /// <summary>
        /// Get DbDataReader column as string nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static string ToStringNullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (string)null : reader.GetString(index).Trim();
        }

        // TimeSpan

        /// <summary>
        /// Get DbDataReader column as TimeSpan.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? new TimeSpan() : (TimeSpan)reader.GetValue(index);
        }

        /// <summary>
        /// Get DbDataReader column as TimeSpan nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static TimeSpan? ToTimeSpanNullable(this DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? (TimeSpan?)null : (TimeSpan?)reader.GetValue(index);
        }

        #endregion DbDataReader To... :: int index

        #region DbDataReader To... :: string column

        // Binary

        /// <summary>
        /// Get DbDataReader column as byte[].
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static byte[] ToBinary(this DbDataReader reader, string column)
        {
            return ToBinary(reader, reader.GetOrdinal(column));
        }

        /// <summary>
        /// Get DbDataReader column as byte[] nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static byte[] ToBinaryNullable(this DbDataReader reader, string column)
        {
            return ToBinaryNullable(reader, reader.GetOrdinal(column));
        }

        // Boolean

        /// <summary>
        /// Get DbDataReader column as bool.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static bool ToBoolean(this DbDataReader reader, string column)
        {
            return ToBoolean(reader, reader.GetOrdinal(column));
        }

        /// <summary>
        /// Get DbDataReader column as bool nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static Boolean? ToBooleanNullable(this DbDataReader reader, string column)
        {
            return ToBooleanNullable(reader, reader.GetOrdinal(column));
        }

        // DateTime

        /// <summary>
        /// Get DbDataReader column as DateTime.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DbDataReader reader, string column)
        {
            return ToDateTime(reader, reader.GetOrdinal(column));
        }

        /// <summary>
        /// Get DbDataReader column as DateTime nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNullable(this DbDataReader reader, string column)
        {
            return ToDateTimeNullable(reader, reader.GetOrdinal(column));
        }

        // Decimal

        /// <summary>
        /// Get DbDataReader column as decimal.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static decimal ToDecimal(this DbDataReader reader, string column)
        {
            return ToDecimal(reader, reader.GetOrdinal(column));
        }

        /// <summary>
        /// Get DbDataReader column as decimal nullable
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static decimal? ToDecimalNullable(this DbDataReader reader, string column)
        {
            return ToDecimalNullable(reader, reader.GetOrdinal(column));
        }

        // Double

        /// <summary>
        /// Get DbDataReader column as double.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static double ToDouble(this DbDataReader reader, string column)
        {
            return ToDouble(reader, reader.GetOrdinal(column));
        }

        /// <summary>
        /// Get DbDataReader column as double nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static double? ToDoubleNullable(this DbDataReader reader, string column)
        {
            return ToDoubleNullable(reader, reader.GetOrdinal(column));
        }

        // Guid

        /// <summary>
        /// Get DbDataReader column as Guid.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static Guid ToGuid(this DbDataReader reader, string column)
        {
            return ToGuid(reader, reader.GetOrdinal(column));
        }

        /// <summary>
        /// Get DbDataReader column as Guid nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static Guid? ToGuidNullable(this DbDataReader reader, string column)
        {
            return ToGuidNullable(reader, reader.GetOrdinal(column));
        }

        // Int16

        /// <summary>
        /// Get DbDataReader column as short.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static short ToInt16(this DbDataReader reader, string column)
        {
            return ToInt16(reader, reader.GetOrdinal(column));
        }

        /// <summary>
        /// Get DbDataReader column as short nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static short? ToInt16Nullable(this DbDataReader reader, string column)
        {
            return ToInt16Nullable(reader, reader.GetOrdinal(column));
        }

        // Int32

        /// <summary>
        /// Get DbDataReader column as int.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static int ToInt32(this DbDataReader reader, string column)
        {
            return ToInt32(reader, reader.GetOrdinal(column));
        }

        /// <summary>
        /// Get DbDataReader column as int nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static int? ToInt32Nullable(this DbDataReader reader, string column)
        {
            return ToInt32Nullable(reader, reader.GetOrdinal(column));
        }

        // Int64

        /// <summary>
        /// Get DbDataReader column as long.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static long ToInt64(this DbDataReader reader, string column)
        {
            return ToInt64(reader, reader.GetOrdinal(column));
        }

        /// <summary>
        /// Get DbDataReader column as long nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static long? ToInt64Nullable(this DbDataReader reader, string column)
        {
            return ToInt64Nullable(reader, reader.GetOrdinal(column));
        }

        // Single

        /// <summary>
        /// Get DbDataReader column as float.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static float ToSingle(this DbDataReader reader, string column)
        {
            return ToSingle(reader, reader.GetOrdinal(column));
        }

        /// <summary>
        /// Get DbDataReader column as float nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static float? ToSingleNullable(this DbDataReader reader, string column)
        {
            return ToSingleNullable(reader, reader.GetOrdinal(column));
        }

        // String

        /// <summary>
        /// Get DbDataReader column as string.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static string ToString(this DbDataReader reader, string column)
        {
            return ToString(reader, reader.GetOrdinal(column));
        }

        /// <summary>
        /// Get DbDataReader column as string nullable.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="column">Column</param>
        /// <returns></returns>
        public static string ToStringNullable(this DbDataReader reader, string column)
        {
            return ToStringNullable(reader, reader.GetOrdinal(column));
        }

        #endregion DbDataReader To... :: string column
    }
}