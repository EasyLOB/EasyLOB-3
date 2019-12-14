using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

/*
    System.Boolean      bool
    System.Byte         byte
    System.SByte        sbyte
    System.Char         char
    System.DateTime     DateTime
    System.Decimal      decimal
    System.Double       double
    System.Single       float
    System.Guid         Guid
    System.Int16        short
    System.UInt16       ushort
    System.Int32        int
    System.UInt32       unit
    System.Int64        long
    System.UInt64       ulong
    System.Object       object
    System.String       string
    System.TimeSpan     TimeSpan
 */

namespace EasyLOB.Library
{
    /// <summary>
    /// Library Helper.
    /// </summary>
    public static partial class LibraryHelper
    {
        #region Properties File

        public static Dictionary<ZFileTypes, string> FileAcronyms
        {
            get
            {
                Dictionary<ZFileTypes, string> result = new Dictionary<ZFileTypes, string>();
                foreach (KeyValuePair<ZFileTypes, string> keyValue in FileExtensions)
                {
                    result.Add(keyValue.Key, keyValue.Value.Replace(".", "")); // .pdf => pdf
                }
                return result;
            }
        }

        public static Dictionary<ZFileTypes, string> FileContentTypes
        {
            get
            {
                return new Dictionary<ZFileTypes, string>
                {
                    // Unknown
                    { ZFileTypes.ftUnknown, "" },
                    // Document
                    { ZFileTypes.ftPDF, "application/pdf" },
                    { ZFileTypes.ftDOC, "application/msword" },
                    { ZFileTypes.ftDOCX, "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                    { ZFileTypes.ftTXT, "text/plain" },
                    { ZFileTypes.ftXLS, "application/vnd.ms-excel" },
                    { ZFileTypes.ftXLSX, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                    // Image
                    { ZFileTypes.ftJPG, "image/jpeg" },
                    { ZFileTypes.ftPNG, "image/x-png" },
                    // Audio
                    { ZFileTypes.ftMP3, "audio/x-mp3" },
                    // Video
                    { ZFileTypes.ftAVI, "video/x-msvideo" },
                    { ZFileTypes.ftMOV, "video/quicktime" },
                    { ZFileTypes.ftMP4, "video/mp4" },
                    { ZFileTypes.ftMPEG, "video/mpeg" },
                    { ZFileTypes.ftWMV, "video/x-ms-wmv" },
                    // Mail
                    { ZFileTypes.ftMSG, "application/vnd.ms-outlook" }
                };
            }
        }

        public static Dictionary<ZFileTypes, string> FileExtensions
        {
            get
            {
                return new Dictionary<ZFileTypes, string>
                {
                    // Unknown
                    { ZFileTypes.ftUnknown, "" },
                    // Document
                    { ZFileTypes.ftPDF, ".pdf" },
                    { ZFileTypes.ftDOC, ".doc" },
                    { ZFileTypes.ftDOCX, ".docx" },
                    { ZFileTypes.ftTXT, ".txt" },
                    { ZFileTypes.ftXLS, ".xls" },
                    { ZFileTypes.ftXLSX, ".xlsx" },
                    // Image
                    { ZFileTypes.ftJPG, ".jpg" }, // .jpeg GetFileType()
                    { ZFileTypes.ftPNG, ".png" },
                    // Audio
                    { ZFileTypes.ftMP3, ".mp3" },
                    // Video
                    { ZFileTypes.ftAVI, ".avi" },
                    { ZFileTypes.ftMOV, ".mov" },
                    { ZFileTypes.ftMP4, ".mp4" },
                    { ZFileTypes.ftMPEG, ".mpeg" },
                    { ZFileTypes.ftWMV, ".wmv" },
                    // Mail
                    { ZFileTypes.ftMSG, ".msg" },
                };
            }
        }

        public static Dictionary<ZFileTypes, string> FileIcons
        {
            get
            {
                return new Dictionary<ZFileTypes, string>
                {
                    // Unknown
                    { ZFileTypes.ftUnknown, "" },
                    // Document
                    { ZFileTypes.ftPDF, "pdf.png" },
                    { ZFileTypes.ftDOC, "doc.png" },
                    { ZFileTypes.ftDOCX, "doc.png" },
                    { ZFileTypes.ftTXT, "txt.png" },
                    { ZFileTypes.ftXLS, "xls.png" },
                    { ZFileTypes.ftXLSX, "xls.png" },
                    // Image
                    { ZFileTypes.ftJPG, "image.png" },
                    { ZFileTypes.ftPNG, "image.png" },
                    // Audio
                    { ZFileTypes.ftMP3, "audio.png" },
                    // Video
                    { ZFileTypes.ftAVI, "movie.png" },
                    { ZFileTypes.ftMOV, "movie.png" },
                    { ZFileTypes.ftMP4, "movie.png" },
                    { ZFileTypes.ftMPEG, "movie.png" },
                    { ZFileTypes.ftWMV, "movie.png" }
                };
            }
        }

        #endregion Properties File

        #region Methods

        /// <summary>
        /// Get Regular Expression.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Regular Expression</returns>
        public static string GetRegularExpression(Type type)
        {
            string result = "";

            switch (GetTypeCode(type))
            {
                case TypeCode.DateTime:
                    result = PatternResources.RegularExpression_Date;
                    break;

                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    result = PatternResources.RegularExpression_Float;
                    break;

                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    result = PatternResources.RegularExpression_Integer;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Is another instance of the same application already running ?
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Single Instance Application in C#
        /// http://www.codeproject.com/Articles/4430/Single-Instance-Application-in-C
        /// </remarks>
        public static bool IsApplicationAlreadyRunning()
        {
            string location = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(location);
            string exeFileName = fileInfo.Name;
            bool createdNew;

            Mutex mutex = new Mutex(true, "Global\\" + exeFileName, out createdNew);
            if (createdNew)
            {
                mutex.ReleaseMutex();
            }

            return !createdNew;
        }

        /// <summary>
        /// Is numeric ?
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns>Is numeric ?</returns>
        public static bool IsNumeric(object o)
        {
            return (o == null) ? false : IsNumeric(o.GetType());
        }

        /// <summary>
        /// Is numeric ?
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Is numeric ?</returns>
        public static bool IsNumeric(Type type)
        {
            if (type == null)
            {
                return false;
            }

            TypeCode typeCode = Type.GetTypeCode(type);

            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                case TypeCode.Single:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Convert string to typed object.
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public static object StringToTypedObject(string value, Type type)
        {
            object result = (string)null;

            TypeCode typeCode = GetTypeCode(type);

            switch (typeCode)
            {
                case TypeCode.Boolean:
                    result = value.ToBooleanNullable();
                    break;

                case TypeCode.Byte:
                    result = value.ToByteNullable();
                    break;

                //case TypeCode.SByte:
                //    result = value.ToSingleNullable();
                //    break;

                case TypeCode.Char:
                    result = value.ToCharNullable();
                    break;

                case TypeCode.Decimal:
                    result = value.ToDecimalNullable();
                    break;

                case TypeCode.Double:
                    result = value.ToDoubleNullable();
                    break;

                case TypeCode.Single:
                    result = value.ToSingleNullable();
                    break;

                case TypeCode.Int16:
                    result = value.ToInt16Nullable();
                    break;

                //case TypeCode.UInt16:
                //    result = value.ToUInt16Nullable();
                //    break;

                case TypeCode.Int32:
                    result = value.ToInt32Nullable();
                    break;

                //case TypeCode.UInt32:
                //    result = value.ToUInt32Nullable();
                //    break;

                case TypeCode.Int64:
                    result = value.ToInt64Nullable();
                    break;

                //case TypeCode.UInt64:
                //    result = value.StringToUInt64Nullable();
                //    break;

                case TypeCode.Object:
                    switch (GetTypeName(type))
                    {
                        case "System.Guid":
                            result = value.ToGuidNullable();
                            break;
                    }
                    break;

                case TypeCode.String:
                    result = value.ToStringNullable();
                    break;
            }

            return result;
        }

        #endregion Methods

        #region Methods Array

        /// <summary>
        /// Convert array to nullable array.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="array">Array</param>
        /// <returns>Nullable array</returns>
        public static T?[] ArrayToNullableArray<T>(T[] array) where T : struct
        {
            T?[] nullableArray = new T?[array.Length];

            for (int i = 0; i < array.Length; i++)
                nullableArray[i] = array[i];

            return nullableArray;
        }

        //public static string ListToString(List<string> list)
        //{
        //    //string s = "";
        //    //foreach (string l in list)
        //    //{
        //    //    s += l + "\n";
        //    //}

        //    //return s;

        //    return String.Join("\n", list);
        //}

        /// <summary>
        /// Convert byte array (Binary) to string.
        /// </summary>
        /// <param name="value">Byte array (Binary)</param>
        /// <returns>String</returns>
        public static string BinaryToString(byte[] value)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            return encoding.GetString(value);
        }

        //static byte[] GetByte(string str)
        //{
        //    byte[] bytes = new byte[str.Length * sizeof(char)];

        //    System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);

        //    return bytes;
        //}

        //static string GetString(byte[] bytes)
        //{
        //    char[] chars = new char[bytes.Length / sizeof(char)];

        //    System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);

        //    return new string(chars);
        //}

        #endregion Methods Array

        #region Methods Boolean

        /// <summary>
        /// Is string Boolean true ?
        /// </summary>
        /// <param name="value">String</param>
        /// <returns>Is true ?</returns>
        public static bool BooleanIsTrue(string value)
        {
            bool result = false;

            try { result = (value.ToUpper() == Boolean.TrueString.ToUpper()); }
            catch { }

            return result;
        }

        /// <summary>
        /// Is string Boolean false ?
        /// </summary>
        /// <param name="value">String</param>
        /// <returns>Is false ?</returns>
        public static bool BooleanIsFalse(string value)
        {
            bool result = false;

            try { result = value.ToUpper() == Boolean.FalseString.ToUpper(); }
            catch { }

            return result;
        }

        /// <summary>
        /// Convert Boolean to String.
        /// </summary>
        /// <param name="value">Boolean value</param>
        /// <returns>String value</returns>
        public static string BooleanToString(bool value)
        {
            string result = "";

            try
            {
                result = value ? Boolean.TrueString : Boolean.FalseString;
            }
            catch { }

            return result;
        }

        /// <summary>
        /// Convert nullable Boolean to String.
        /// </summary>
        /// <param name="value">Nullable Boolean value</param>
        /// <returns>String value</returns>
        public static bool DataToBoolean(bool? value)
        {
            if (!value.HasValue)
            {
                return false;
            }
            else
            {
                return (bool)value;
            }
        }

        /// <summary>
        /// Convert Boolean to Boolean.
        /// </summary>
        /// <param name="value">Boolean value</param>
        /// <returns>Boolean value</returns>
        public static Boolean BooleanToBoolean(bool value)
        {
            return value;
        }

        /// <summary>
        /// Convert Boolean to nullable Boolean.
        /// </summary>
        /// <param name="value">Boolean value</param>
        /// <returns>Boolean value</returns>
        public static Boolean? BooleanToBooleanNullable(bool value)
        {
            return (Boolean?)value;
        }

        #endregion Methods Boolean

        #region Methods DateTime

        static public DateTime FirstDayOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        static public DateTime LastDayOfMonth(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }

        static public DateTime FirstDayOfYear(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 1, 1);
        }

        static public DateTime LastDayOfYear(DateTime dateTime)
        {
            dateTime = new DateTime(dateTime.Year + 1, 1, 1);
            return dateTime.AddDays(-1);
        }

        #endregion Methods DateTime

        #region Methods DataToObject

        /// <summary>
        /// Convert Boolean to Object.
        /// </summary>
        /// <param name="value">Boolean value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(bool? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            };
        }

        /// <summary>
        /// Convert Binary to Object.
        /// </summary>
        /// <param name="value">Byte array (Binary) value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(byte[] value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert Byte to Object.
        /// </summary>
        /// <param name="value">Byte value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(byte? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert SByte to Object.
        /// </summary>
        /// <param name="value">Sbyte value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(sbyte? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert Char to Object.
        /// </summary>
        /// <param name="value">Char value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(char? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert DateTime to Object.
        /// </summary>
        /// <param name="value">DateTime value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(DateTime? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert Decimal to Object.
        /// </summary>
        /// <param name="value">Decimal value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(decimal? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert Double to Object.
        /// </summary>
        /// <param name="value">Double value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(double? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert Guid to Object.
        /// </summary>
        /// <param name="value">Guid value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(Guid? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert Int32 to Object.
        /// </summary>
        /// <param name="value">Int32 value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(int? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert UInt32 to Object.
        /// </summary>
        /// <param name="value">UInt32 value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(uint? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert Int64 to Object.
        /// </summary>
        /// <param name="value">Int64 value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(long? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert UInt64 to Object.
        /// </summary>
        /// <param name="value">UInt64 value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(ulong? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert Int16 to Object.
        /// </summary>
        /// <param name="value">Int16 value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(short? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert UInt16 to Object.
        /// </summary>
        /// <param name="value">UInt16 value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(ushort? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert Object to Object.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert Single to Object.
        /// </summary>
        /// <param name="value">Single value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(float? value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Convert String to Object.
        /// </summary>
        /// <param name="value">String value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(string value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value.Trim();
            }
        }

        /// <summary>
        /// Convert TimeSpan to Object.
        /// </summary>
        /// <param name="value">TimeSpan value</param>
        /// <returns>Object value</returns>
        public static object DataToObject(TimeSpan value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        #endregion Methods DataToObject

        #region Methods DataToString

        // Boolean

        /// <summary>
        /// Convert Boolean to String.
        /// </summary>
        /// <param name="value">Boolean value</param>
        /// <returns>String value</returns>
        public static string DataToString(bool? value)
        {
            if (!value.HasValue)
            {
                return "";
            }
            else
            {
                return ((bool)value ? Boolean.TrueString : Boolean.FalseString);
            }
        }

        // Binary

        /// <summary>
        /// Convert Binary to String.
        /// </summary>
        /// <param name="value">Byte array (Binary) value</param>
        /// <returns>String value</returns>
        public static string DataToString(byte[] value)
        {
            if (value == null || value.Length == 0)
            {
                return "";
            }
            else
            {
                byte[] valueNotNullable = new byte[value.Length];

                for (int i = 0; i < value.Length; i++)
                    valueNotNullable[i] = (byte)value[i];

                return (BinaryToString(valueNotNullable));
            }
        }

        // Byte

        /// <summary>
        /// Convert Byte to String.
        /// </summary>
        /// <param name="value">Byte value</param>
        /// <returns>String value</returns>
        public static string DataToString(byte? value)
        {
            return DataToString(value, PatternResources.Format_String);
        }

        /// <summary>
        /// Convert Byte to String.
        /// </summary>
        /// <param name="value">Byte value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(byte? value, string format)
        {
            if (!value.HasValue)
            {
                return "";
            }
            else
            {
                return ((byte)value).ToString(format);
            }
        }

        // SByte

        /// <summary>
        /// Convert SByte to String.
        /// </summary>
        /// <param name="value">SByte value</param>
        /// <returns>String value</returns>
        public static string DataToString(sbyte? value)
        {
            return DataToString(value, PatternResources.Format_String);
        }

        /// <summary>
        /// Convert SByte to String.
        /// </summary>
        /// <param name="value">SByte value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(sbyte? value, string format)
        {
            if (!value.HasValue)
            {
                return "";
            }
            else
            {
                return ((sbyte)value).ToString(format);
            }
        }

        // DateTime

        /// <summary>
        /// Convert DateTime to String.
        /// </summary>
        /// <param name="value">DateTime value</param>
        /// <returns>String value</returns>
        public static string DataToString(DateTime? value)
        {
            return DataToString(value, PatternResources.Format_Date);
        }

        /// <summary>
        /// Convert DateTime to String.
        /// </summary>
        /// <param name="value">DateTime value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(DateTime? value, string format)
        {
            if (!value.HasValue)
            {
                return "";
            }
            else
            {
                return ((DateTime)value).ToString(format);
            }
        }

        // Decimal

        /// <summary>
        /// Convert Decimal to String.
        /// </summary>
        /// <param name="value">Decimal value</param>
        /// <returns>String value</returns>
        public static string DataToString(decimal? value)
        {
            return DataToString(value, PatternResources.Format_Float);
        }

        /// <summary>
        /// Convert Decimal to String.
        /// </summary>
        /// <param name="value">Decimal value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(decimal? value, string format)
        {
            if (!value.HasValue)
            {
                return "";
            }
            else
            {
                return ((decimal)value).ToString(format);
            }
        }

        // Double

        /// <summary>
        /// Convert Double to String.
        /// </summary>
        /// <param name="value">Double value</param>
        /// <returns>String value</returns>
        public static string DataToString(double? value)
        {
            return DataToString(value, PatternResources.Format_Float);
        }

        /// <summary>
        /// Convert Double to String.
        /// </summary>
        /// <param name="value">Double value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(double? value, string format)
        {
            if (!value.HasValue)
            {
                return "";
            }
            else
            {
                return ((double)value).ToString(format);
            }
        }

        // Guid

        /// <summary>
        /// Convert Guid to String.
        /// </summary>
        /// <param name="value">Guid value</param>
        /// <returns>String value</returns>
        public static string DataToString(Guid? value)
        {
            if (!value.HasValue)
                return "";
            else
                return ((Guid)value).ToString();
        }

        // Int16

        /// <summary>
        /// Convert Int16 to String.
        /// </summary>
        /// <param name="value">Int16 value</param>
        /// <returns>String value</returns>
        public static string DataToString(short? value)
        {
            return DataToString(value, PatternResources.Format_Integer);
        }

        /// <summary>
        /// Convert Int16 to String.
        /// </summary>
        /// <param name="value">Int16 value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(short? value, string format)
        {
            if (!value.HasValue)
                return "";
            else
                return ((int)value).ToString(format);
        }

        // UInt16

        /// <summary>
        /// Convert UInt16 to String.
        /// </summary>
        /// <param name="value">UInt16 value</param>
        /// <returns>String value</returns>
        public static string DataToString(ushort? value)
        {
            return DataToString(value, PatternResources.Format_Integer);
        }

        /// <summary>
        /// Convert UInt16 to String.
        /// </summary>
        /// <param name="value">UInt16 value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(ushort? value, string format)
        {
            if (!value.HasValue)
                return "";
            else
                return ((uint)value).ToString(format);
        }

        // Int32

        /// <summary>
        /// Convert Int32 to String.
        /// </summary>
        /// <param name="value">Int32 value</param>
        /// <returns>String value</returns>
        public static string DataToString(int? value)
        {
            return DataToString(value, PatternResources.Format_Integer);
        }

        /// <summary>
        /// Convert Int32 to String.
        /// </summary>
        /// <param name="value">Int32 value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(int? value, string format)
        {
            if (!value.HasValue)
                return "";
            else
                return ((int)value).ToString(format);
        }

        // UInt32

        /// <summary>
        /// Convert UInt32 to String.
        /// </summary>
        /// <param name="value">UInt32 value</param>
        /// <returns>String value</returns>
        public static string DataToString(uint? value)
        {
            return DataToString(value, PatternResources.Format_Integer);
        }

        /// <summary>
        /// Convert UInt32 to String.
        /// </summary>
        /// <param name="value">UInt32 value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(uint? value, string format)
        {
            if (!value.HasValue)
                return "";
            else
                return ((uint)value).ToString(format);
        }

        // Int64

        /// <summary>
        /// Convert Int64 to String.
        /// </summary>
        /// <param name="value">Int64 value</param>
        /// <returns>String value</returns>
        public static string DataToString(long? value)
        {
            return DataToString(value, PatternResources.Format_Integer);
        }

        /// <summary>
        /// Convert Int64 to String.
        /// </summary>
        /// <param name="value">Int64 value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(long? value, string format)
        {
            if (!value.HasValue)
                return "";
            else
                return ((long)value).ToString(format);
        }

        // UInt64

        /// <summary>
        /// Convert UInt64 to String.
        /// </summary>
        /// <param name="value">UInt64 value</param>
        /// <returns>String value</returns>
        public static string DataToString(ulong? value)
        {
            return DataToString(value, PatternResources.Format_Integer);
        }

        /// <summary>
        /// Convert UInt64 to String.
        /// </summary>
        /// <param name="value">UInt64 value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(ulong? value, string format)
        {
            if (!value.HasValue)
                return "";
            else
                return ((ulong)value).ToString(format);
        }

        // Single

        /// <summary>
        /// Convert Single to String.
        /// </summary>
        /// <param name="value">Single value</param>
        /// <returns>String value</returns>
        public static string DataToString(float? value)
        {
            return DataToString(value, PatternResources.Format_Float);
        }

        /// <summary>
        /// Convert Single to String.
        /// </summary>
        /// <param name="value">Single value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(float? value, string format)
        {
            if (!value.HasValue)
            {
                return "";
            }
            else
            {
                return ((float)value).ToString(format);
            }
        }

        // String

        /// <summary>
        /// Convert String to String.
        /// </summary>
        /// <param name="value">String value</param>
        /// <returns>String value</returns>
        public static string DataToString(string value)
        {
            return DataToString(value, PatternResources.Format_String);
        }

        /// <summary>
        /// Convert String to String.
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(string value, string format) // DbType.XML
        {
            if (String.IsNullOrEmpty(value))
            {
                return "";
            }
            else
            {
                return value;
            }
        }

        // TimeSpan

        /// <summary>
        /// Convert TimeSpan to String.
        /// </summary>
        /// <param name="value">TimeSpan value</param>
        /// <returns>String value</returns>
        public static string DataToString(TimeSpan? value)
        {
            return DataToString(value, PatternResources.Format_String);
        }

        /// <summary>
        /// Convert TimeSpan to String.
        /// </summary>
        /// <param name="value">TimeSpan value</param>
        /// <param name="format">Format</param>
        /// <returns>String value</returns>
        public static string DataToString(TimeSpan? value, string format)
        {
            if (!value.HasValue)
            {
                return "";
            }
            else
            {
                return ((TimeSpan)value).ToString(format);
            }
        }

        #endregion Methods DataToString

        #region Methods File

        /// <summary>
        /// Clean directory.
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <param name="directory">Directory</param>
        /// <returns></returns>
        public static bool CleanDirectory(ZOperationResult operationResult, string directory)
        {
            try
            {
                string[] paths;

                paths = Directory.GetFiles(directory);
                foreach (string path in paths)
                {
                    File.Delete(path);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return operationResult.Ok;
        }

        /// <summary>
        /// Get acronym.
        /// </summary>
        /// <param name="fileType">File type</param>
        /// <returns>Acronym</returns>
        public static string GetAcronym(ZFileTypes fileType)
        {
            string acronym;

            if (!LibraryHelper.FileAcronyms.TryGetValue(fileType, out acronym))
            {
                LibraryHelper.FileContentTypes.TryGetValue(ZFileTypes.ftUnknown, out acronym);
            }

            return acronym;
        }

        /// <summary>
        /// Get content type.
        /// </summary>
        /// <param name="fileType">File type</param>
        /// <returns>Content type</returns>
        public static string GetContentType(ZFileTypes fileType)
        {
            string contentType;

            if (!LibraryHelper.FileContentTypes.TryGetValue(fileType, out contentType))
            {
                LibraryHelper.FileContentTypes.TryGetValue(ZFileTypes.ftUnknown, out contentType);
            }

            return contentType;
        }

        /// <summary>
        /// Get file extension.
        /// </summary>
        /// <param name="fileType">File type</param>
        /// <returns>File extension</returns>
        public static string GetFileExtension(ZFileTypes fileType)
        {
            string extension;

            if (!LibraryHelper.FileExtensions.TryGetValue(fileType, out extension))
            {
                LibraryHelper.FileExtensions.TryGetValue(ZFileTypes.ftUnknown, out extension);
            }

            return extension;
        }

        /// <summary>
        /// Get file type.
        /// </summary>
        /// <param name="acronymOrExtension">File acronym (pdf) or extension (.pdf)</param>
        /// <returns>File type</returns>
        public static ZFileTypes GetFileType(string acronymOrExtension)
        {
            ZFileTypes fileType = ZFileTypes.ftUnknown;

            acronymOrExtension = acronymOrExtension.ToLower();
            acronymOrExtension = acronymOrExtension.Replace("jpeg", "jpg");

            // Acronyms

            foreach (KeyValuePair<ZFileTypes, string> keyValue in LibraryHelper.FileAcronyms)
            {
                if (keyValue.Value == acronymOrExtension)
                {
                    fileType = keyValue.Key;
                    break;
                }
            }

            // Extensions

            if (fileType == (int)ZFileTypes.ftUnknown)
            {
                foreach (KeyValuePair<ZFileTypes, string> keyValue in LibraryHelper.FileExtensions)
                {
                    if (keyValue.Value == acronymOrExtension)
                    {
                        fileType = keyValue.Key;
                        break;
                    }
                }
            }

            return fileType;
        }

        /// <summary>
        /// Get icon.
        /// </summary>
        /// <param name="fileType">File type</param>
        /// <returns>Icon file name</returns>
        public static string GetIcon(ZFileTypes fileType)
        {
            string icon = "";

            if (!LibraryHelper.FileIcons.TryGetValue(fileType, out icon))
            {
                LibraryHelper.FileIcons.TryGetValue(ZFileTypes.ftUnknown, out icon);
            }

            return icon;
        }

        /// <summary>
        /// Get icon.
        /// </summary>
        /// <param name="acronymOrExtension">File acronym (pdf) or extension (.pdf)</param>
        /// <returns>Icon file name</returns>
        public static string GetIcon(string acronymOrExtension)
        {
            string icon = "";

            if (!LibraryHelper.FileIcons.TryGetValue(GetFileType(acronymOrExtension), out icon))
            {
                LibraryHelper.FileIcons.TryGetValue(ZFileTypes.ftUnknown, out icon);
            }

            return icon;
        }

        #endregion Methods File

        #region Methods IO

        /// <summary>
        /// Add directory separator, if necessary.
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns></returns>
        public static string AddDirectorySeparator(string path)
        {
            // Path.AltDirectorySeparatorChar = /
            // Path.DirectorySeparatorChar = \
            // Path.PathSeparator = ;
            // Path.VolumeSeparatorChar = :

            if (!String.IsNullOrEmpty(path))
            {
                string separator = Path.DirectorySeparatorChar.ToString();
                string altSeparator = Path.AltDirectorySeparatorChar.ToString();

                path = path.Trim();

                if (path.EndsWith(separator) || path.EndsWith(altSeparator))
                {
                    return path;
                }

                if (path.Contains(separator)) // [\]
                {
                    return path + separator;
                }

                if (!String.IsNullOrEmpty(path)) // [/]
                {
                    return path + altSeparator;
                }

                //if (path.Contains(altSeparator))
                //{
                //    return path + altSeparator;
                //}

                //if (!String.IsNullOrEmpty(path))
                //{
                //    return path + separator;
                //}
            }

            return path;
        }

        #endregion Methods IO

        #region Methods Math

        public static double? Zero(double? d)
        {
            return d == null || d < 0 ? 0 : d;
        }
        public static double Zero(double d)
        {
            return d < 0 ? 0 : d;
        }

        #endregion Methods Math

        #region Methods Message

        public static string MessageNotFound(string entity)
        {
            return entity + " " + ErrorResources.NotFound;
        }

        public static string MessageNotFound(string entity, object[] ids)
        {
            string result = "";

            foreach (object id in ids)
            {
                result = (String.IsNullOrEmpty(result) ? "" : ", ") + id.ToString();
            }

            result = entity + " [" + result + "] " + ErrorResources.NotFound;

            return result;
        }

        #endregion Methods Message

        #region Methods ObjectTo... | ObjectTo...Nullable

        // Binary

        /// <summary>
        /// Convert Object to byte[] (Binary).
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>byte[] (Binary) value</returns>
        public static byte[] ObjectToBinary(object value)
        {
            try
            {
                return (byte[])value;
            }
            catch
            {
                return new byte[] { };
            }
        }

        /// <summary>
        /// Convert Object to nullable byte[] (Binary).
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable byte[] (Binary) value</returns>
        public static byte[] ObjectToBinaryNullable(object value)
        {
            try
            {
                return (byte[])value;
            }
            catch
            {
                return null;
            }
        }

        // Boolean

        /// <summary>
        /// Convert Object to Boolean.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Boolean value</returns>
        public static bool ObjectToBoolean(object value)
        {
            if (value == null)
            {
                return LibraryDefaults.Default_Boolean;
            }
            else
            {
                return (bool)value;
            }
        }

        /// <summary>
        /// Convert Object to nullable Boolean.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable Boolean value</returns>
        public static bool? ObjectToBooleanNullable(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return (bool?)value;
            }
        }

        // Byte

        /// <summary>
        /// Convert Object to Byte.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Byte value</returns>
        public static byte ObjectToByte(object value)
        {
            if (value == null)
            {
                return LibraryDefaults.Default_Byte;
            }
            else
            {
                return (byte)value;
            }
        }

        /// <summary>
        /// Convert Object to nullable Byte.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nulllable Byte value</returns>
        public static byte? ObjectToByteNullable(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return (byte?)value;
            }
        }

        // Char

        /// <summary>
        /// Convert Object to Char.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Char value</returns>
        public static char ObjectToChar(object value)
        {
            if (value == null)
            {
                return LibraryDefaults.Default_Char;
            }
            else
            {
                return (char)value;
            }
        }

        /// <summary>
        /// Convert Object to nullable Char.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable Char value</returns>
        public static char? ObjectToCharNullable(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return (char?)value;
            }
        }

        // DateTime

        /// <summary>
        /// Convert Object to DateTime.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>DateTime value</returns>
        public static DateTime ObjectToDateTime(object value)
        {
            try
            {
                return (DateTime)value;
            }
            catch
            {
                return LibraryDefaults.Default_DateTime;
            }
        }

        /// <summary>
        /// Convert Object to nullable DateTime.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable DateTime value</returns>
        public static DateTime? ObjectToDateTimeNullable(object value)
        {
            try
            {
                return (DateTime)value;
            }
            catch
            {
                return null;
            }
        }

        // Decimal

        /// <summary>
        /// Convert Object to Decimal.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Decimal value</returns>
        public static decimal ObjectToDecimal(object value)
        {
            if (value == null)
            {
                return LibraryDefaults.Default_Decimal;
            }
            else
            {
                return (decimal)value;
            }
        }

        /// <summary>
        /// Convert Object to nullable Decimal.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable Decimal value</returns>
        public static decimal? ObjectToDecimalNullable(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return (decimal?)value;
            }
        }

        // Double

        /// <summary>
        /// Convert Object to Double.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Double value</returns>
        public static double ObjectToDouble(object value)
        {
            if (value == null)
            {
                return LibraryDefaults.Default_Double;
            }
            else
            {
                return (double)value;
            }
        }

        /// <summary>
        /// Convert Object to nullable Double.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable Double value</returns>
        public static double? ObjectToDoubleNullable(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return (double?)value;
            }
        }

        // Guid

        /// <summary>
        /// Convert Object to Guid.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Guid value</returns>
        public static Guid? ObjectToGuid(object value)
        {
            return ObjectToGuidNullable(value);
        }

        /// <summary>
        /// Convert Object to nullable Guid.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable Guid value</returns>
        public static Guid? ObjectToGuidNullable(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return (Guid?)value;
            }
        }

        // Int16

        /// <summary>
        /// Convert Object to Int16.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Int16 value</returns>
        public static short ObjectToInt16(object value)
        {
            if (value == null)
            {
                return LibraryDefaults.Default_Int16;
            }
            else
            {
                return (short)value;
            }
        }

        /// <summary>
        /// Convert Object to nullable Int16.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable Int16 value</returns>
        public static short? ObjectToInt16Nullable(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return (short?)value;
            }
        }

        // Int32

        /// <summary>
        /// Convert Object to Int32.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Int32 value</returns>
        public static int ObjectToInt32(object value)
        {
            if (value == null)
            {
                return LibraryDefaults.Default_Int32;
            }
            else
            {
                return (int)value;
            }
        }

        /// <summary>
        /// Convert Object to nullable Int32.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable Int32 value</returns>
        public static int? ObjectToInt32Nullable(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return (int?)value;
            }
        }

        // Int64

        /// <summary>
        /// Convert Object to Int64.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Int64 value</returns>
        public static long ObjectToInt64(object value)
        {
            if (value == null)
            {
                return LibraryDefaults.Default_Int64;
            }
            else
            {
                return (long)value;
            }
        }

        /// <summary>
        /// Convert Object to nullable Int64.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable Int64 value</returns>
        public static long? ObjectToInt64Nullable(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return (long?)value;
            }
        }

        // Object

        /// <summary>
        /// Convert Object to Object.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Object value</returns>
        public static object ObjectToObject(object value)
        {
            return ObjectToObjectNullable(value);
        }

        /// <summary>
        /// Convert Object to nullable Object.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable Object value</returns>
        public static object ObjectToObjectNullable(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return value;
            }
        }

        // Single

        /// <summary>
        /// Convert Object to Single.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Single value</returns>
        public static float ObjectToSingle(object value)
        {
            if (value == null)
            {
                return LibraryDefaults.Default_Single;
            }
            else
            {
                return (float)value;
            }
        }

        /// <summary>
        /// Convert Object to nullable Single.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable Single value</returns>
        public static float? ObjectToSingleNullable(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return (float?)value;
            }
        }

        // String

        /// <summary>
        /// Convert Object to String.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>String value</returns>
        public static string ObjectToString(object value)
        {
            try
            {
                return (string)value;
            }
            catch
            {
                return LibraryDefaults.Default_String;
            }
        }

        /// <summary>
        /// Convert Object to nullable String.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable String value</returns>
        public static string ObjectToStringNullable(object value)
        {
            try
            {
                return (string)value;
            }
            catch
            {
                return null;
            }
        }

        // TimeSpan

        /// <summary>
        /// Convert Object to TimeSpan.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>TimeSpan value</returns>
        public static TimeSpan ObjectToTimeSpan(object value)
        {
            try
            {
                return (TimeSpan)value;
            }
            catch
            {
                return new TimeSpan();
            }
        }

        /// <summary>
        /// Convert Object to nullable TimeSpan.
        /// </summary>
        /// <param name="value">Object value</param>
        /// <returns>Nullable TimeSpane value</returns>
        public static TimeSpan? ObjectToTimeSpanNullable(object value)
        {
            try
            {
                return (TimeSpan)value;
            }
            catch
            {
                return null;
            }
        }

        #endregion Methods ObjectTo... | ObjectTo...Nullable

        #region Methods Reflection

        private readonly static object _lock = new object();

        public static T Clone<T>(T from)
        {
            return Clone<T>(from, null);
        }

        public static T Clone<T>(T from, List<string> excludedProperties)
        {
            T to = Activator.CreateInstance<T>();

            Clone<T>(from, to, excludedProperties);

            return to;
        }

        public static void Clone<T>(T from, Object to)
        {
            Clone(from, to, null);
        }

        public static void Clone<T>(T from, Object to, List<string> excludedProperties)
        {
            if (from != null && to != null)
            {
                try
                {
                    Monitor.Enter(_lock);
                    const BindingFlags bindingFlags =
                        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
                    PropertyInfo[] properties = typeof(T).GetProperties(bindingFlags);
                    foreach (PropertyInfo property in properties)
                    {
                        if (excludedProperties == null || !excludedProperties.Contains(property.Name))
                        {
                            if (property.GetValue(to, null) != property.GetValue(from, null))
                            {
                                if (property.PropertyType == typeof(String))
                                {
                                    string value = (String)property.GetValue(from, null);
                                    value = value == null ? value : value.Trim();
                                    property.SetValue(to, value, null);
                                }
                                else
                                {
                                    property.SetValue(to, property.GetValue(from, null), null);
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }

        /// <summary>
        /// Create instance.
        /// </summary>
        /// <param name="type">Instance Type</param>
        /// <returns>Instance</returns>
        public static object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }

        /// <summary>
        /// Create instance.
        /// </summary>
        /// <param name="type">Instance Type</param>
        /// <param name="args">Arguments</param>
        /// <returns>Instance</returns>
        public static object CreateInstance(Type type, object[] args)
        {
            return Activator.CreateInstance(type, args);
        }

        /// <summary>
        /// Get Assembly.
        /// </summary>
        /// <param name="name">Assembly name</param>
        /// <returns>Assembly</returns>
        public static Assembly GetAssembly(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == name);
        }

        #endregion Method Reflection

        #region Methods Reflection Type

        /// <summary>
        /// Get Class Type.
        /// </summary>
        /// <param name="className">Class name</param>
        /// <returns>Type</returns>
        public static Type GetType(string className)
        {
            Type type = Type.GetType(className); // Class Library

            if (type == null)
            {
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assembly in assemblies) // Class Library
                {
                    type = assembly.GetType(className);
                    if (type != null)
                    {
                        break;
                    }
                }
            }

            //if (type == null)
            //{
            //    type = Type.GetType(className + ", App_Code"); // App_Code
            //}

            return type;
        }

        /// <summary>
        /// Get Property Type.
        /// </summary>
        /// <param name="className">Class name</param>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        public static Type GetType(string className, string propertyName)
        {
            return GetType(GetType(className), propertyName);
        }

        /// <summary>
        /// Get Property Type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>Type</returns>
        public static Type GetType(Type type, string propertyName)
        {
            try
            {
                PropertyInfo p = type.GetProperty(propertyName);
                type = p.PropertyType;
            }
            catch
            {
                type = null;
            }

            return type;
        }

        /// <summary>
        /// Get Type Code.
        /// </summary>
        /// <param name="className">Class name</param>
        /// <returns></returns>
        public static TypeCode GetTypeCode(string className)
        {
            return Type.GetTypeCode(GetType(className));
        }

        /// <summary>
        /// Get Type Code.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public static TypeCode GetTypeCode(Type type)
        {
            return Type.GetTypeCode(type);
        }

        /// <summary>
        /// Get Type Code.
        /// </summary>
        /// <param name="className">Class name</param>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        public static TypeCode GetTypeCode(string className, string propertyName)
        {
            TypeCode typeCode = TypeCode.String;

            try
            {
                Type propertyType = GetType(className, propertyName);
                typeCode = GetTypeCode(propertyType);
            }
            catch { }

            return typeCode;
        }

        /// <summary>
        /// Get Type Code.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        public static TypeCode GetTypeCode(Type type, string propertyName)
        {
            TypeCode typeCode = TypeCode.String;

            try
            {
                Type propertyType = GetType(type, propertyName);
                typeCode = GetTypeCode(propertyType);
            }
            catch { }

            return typeCode;
        }

        /// <summary>
        /// Get Type name.
        /// </summary>
        /// <param name="className">Class name</param>
        /// <returns>Type name</returns>
        public static string GetTypeName(string className)
        {
            string typeName = "";

            try
            {
                Type type = GetType(className);
                typeName = GetTypeName(type);
            }
            catch { }

            return typeName;
        }

        /// <summary>
        /// Get Type name.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Type name</returns>
        public static string GetTypeName(Type type)
        {
            string typeName = "";

            try
            {
                typeName = type.ToString(); // System.Nullable[System.Int32]
                int index = typeName.IndexOf('[');
                if (index >= 0)
                    typeName = typeName.Substring(index + 1).Replace("]", "");
            }
            catch { }

            return typeName;
        }

        /// <summary>
        /// Get Property Type name.
        /// </summary>
        /// <param name="className">Class name</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>Property Type name</returns>
        public static string GetTypeName(string className, string propertyName)
        {
            string typeName = "";

            try
            {
                Type propertyType = GetType(className, propertyName);
                typeName = GetTypeName(propertyType);
            }
            catch { }

            return typeName;
        }

        /// <summary>
        /// Get Property Type name.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>Property Type name</returns>
        public static string GetTypeName(Type type, string propertyName)
        {
            string typeName = "";

            try
            {
                Type propertyType = GetType(type, propertyName);
                typeName = GetTypeName(propertyType);
            }
            catch { }

            return typeName;
        }

        #endregion Methods Reflection Type

        #region Methods Reflection Field

        /// <summary>
        /// Get Fields.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Fields</returns>
        public static List<string> GetFields(Type type)
        {
            List<string> result = new List<string>();
            const BindingFlags bindingFlags =
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
            FieldInfo[] fields = type.GetFields(bindingFlags);
            foreach (FieldInfo field in fields)
            {
                result.Add(field.Name);
            }

            return result;
        }

        /// <summary>
        /// Get Field.
        /// </summary>
        /// <param name="type">Type name</param>
        /// <param name="fieldName">Field name</param>
        /// <returns>Property</returns>
        public static FieldInfo GetField(Type type, string fieldName)
        {
            const BindingFlags bindingFlags =
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

            return type.GetField(fieldName, bindingFlags);
        }

        /// <summary>
        /// Get Field value.
        /// </summary>
        /// <param name="instance">Instance</param>
        /// <param name="fieldName">Field name</param>
        /// <returns></returns>
        public static object GetFieldValue(object instance, string fieldName)
        {
            Type type = instance.GetType();
            const BindingFlags bindingFlags =
                BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
            FieldInfo field = type.GetField(fieldName, bindingFlags);

            return field.GetValue(instance);
        }

        /// <summary>
        /// Get static Field value.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="fieldName">Field name</param>
        /// <returns></returns>
        public static object GetStaticFieldValue(Type type, string fieldName)
        {
            const BindingFlags bindingFlags =
                BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
            FieldInfo field = type.GetField(fieldName, bindingFlags);

            return field.GetValue(null); // static => object = null
        }

        /// <summary>
        /// Has Field ?
        /// </summary>
        /// <param name="type">Type name</param>
        /// <param name="fieldName">Field name</param>
        /// <returns></returns>
        public static bool HasField(Type type, string fieldName)
        {
            return GetField(type, fieldName) != null;
        }

        #endregion Methods Reflection Field

        #region Methods Reflection Property

        /// <summary>
        /// Get Properties.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Properties</returns>
        public static List<string> GetProperties(Type type)
        {
            List<string> result = new List<string>();
            const BindingFlags bindingFlags =
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
            PropertyInfo[] properties = type.GetProperties(bindingFlags);
            foreach (PropertyInfo property in properties)
            {
                result.Add(property.Name);
            }

            return result;
        }

        /// <summary>
        /// Get Property.
        /// </summary>
        /// <param name="type">Type name</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>Property</returns>
        public static PropertyInfo GetProperty(Type type, string propertyName)
        {
            const BindingFlags bindingFlags =
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

            return type.GetProperty(propertyName, bindingFlags);
        }

        /// <summary>
        /// Get Property value.
        /// </summary>
        /// <param name="instance">Instance</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>Property value</returns>
        public static object GetPropertyValue(object instance, string propertyName)
        {
            Type type = instance.GetType();
            const BindingFlags bindingFlags =
                BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
            PropertyInfo property = type.GetProperty(propertyName, bindingFlags);

            //return property.GetValue(instance, null);
            return property.GetValue(instance);
        }

        /// <summary>
        /// Get static Property value.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>Property value</returns>
        public static object GetStaticPropertyValue(Type type, string propertyName)
        {
            const BindingFlags bindingFlags =
                BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
            PropertyInfo property = type.GetProperty(propertyName, bindingFlags);

            //return property.GetValue(null, null); // static => object = null
            return property.GetValue(null); // static => object = null
        }

        /// <summary>
        /// Has Property ?
        /// </summary>
        /// <param name="type">Type name</param>
        /// <param name="PropertyName">Property name</param>
        /// <returns></returns>
        public static bool HasProperty(Type type, string PropertyName)
        {
            return GetProperty(type, PropertyName) != null;
        }

        /// <summary>
        /// Set Property value.
        /// </summary>
        /// <param name="instance">Instance</param>
        /// <param name="propertyName">Property name</param>
        /// <param name="value">Value</param>
        /// <returns>Property value</returns>
        public static void SetPropertyValue(object instance, string propertyName, object value)
        {
            Type type = instance.GetType();
            PropertyInfo property = GetProperty(type, propertyName);
            if (property != null)
            {
                property.SetValue(instance, value, null);
            }
        }

        #endregion Methods Reflection Property

        #region Methods Reflection Method

        /// <summary>
        /// Get Method.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="methodName">Method name</param>
        /// <returns>Method</returns>
        public static MethodInfo GetMethod(Type type, string methodName)
        {
            const BindingFlags bindingFlags =
                BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

            return type.GetMethod(methodName, bindingFlags);
        }

        /// <summary>
        /// Has Method ?
        /// </summary>
        /// <param name="type">Type name</param>
        /// <param name="methodName">Method name</param>
        /// <returns></returns>
        public static bool HasMethod(Type type, string methodName)
        {
            return GetMethod(type, methodName) != null;
        }

        /// <summary>
        /// Invoke static method.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="methodName">Method name</param>
        /// <param name="args">Parameters</param>
        /// <returns>Method result</returns>
        public static object InvokeMethod(Type type, string methodName, object[] args)
        {
            const BindingFlags bindingFlags =
                BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
            MethodInfo method = type.GetMethod(methodName, bindingFlags);

            if (method != null)
            {
                return method.Invoke(null, args);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Invoke instance method.
        /// </summary>
        /// <param name="instance">Instance</param>
        /// <param name="methodName">Method name</param>
        /// <param name="args">Parameters</param>
        /// <returns>Method result</returns>
        public static object InvokeMethod(object instance, string methodName, object[] args)
        {
            Type type = instance.GetType();
            const BindingFlags bindingFlags =
                BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
            MethodInfo method = type.GetMethod(methodName, bindingFlags);

            if (method != null)
            {
                return method.Invoke(instance, args);
            }
            else
            {
                return null;
            }
        }

        #endregion Methods Reflection Method

        #region Methods Type

        public static bool IsNullable(Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }

        public static bool IsBoolean(Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type);
            underlyingType = underlyingType == null ? type : underlyingType;

            return (underlyingType == typeof(Boolean));
        }

        public static bool IsDateTime(Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type);
            underlyingType = underlyingType == null ? type : underlyingType;

            return (underlyingType == typeof(DateTime));
        }

        public static bool IsFloat(Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type);
            underlyingType = underlyingType == null ? type : underlyingType;

            return (underlyingType == typeof(Decimal)
                || underlyingType == typeof(Double)
                || underlyingType == typeof(Single));
        }

        public static bool IsGuid(Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type);
            underlyingType = underlyingType == null ? type : underlyingType;

            return (underlyingType == typeof(Guid));
        }

        public static bool IsInteger(Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type);
            underlyingType = underlyingType == null ? type : underlyingType;

            return (underlyingType == typeof(Byte)
                || underlyingType == typeof(SByte)
                || underlyingType == typeof(Int32)
                || underlyingType == typeof(Int64)
                || underlyingType == typeof(UInt16)
                || underlyingType == typeof(UInt32)
                || underlyingType == typeof(UInt64));
        }

        public static bool IsString(Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type);
            underlyingType = underlyingType == null ? type : underlyingType;

            return (underlyingType == typeof(Char)
                || underlyingType == typeof(String));
        }

        #endregion Methods Type
    }
}