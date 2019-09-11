using System;

namespace EasyLOB.Library
{
    /// <summary>
    /// Library Defaults.
    /// </summary>
    public static partial class LibraryDefaults
    {
        #region Properties

        public static byte[] Default_Binary { get { return new byte[] { }; } }

        public static bool Default_Boolean { get { return false; } }

        public static byte Default_Byte { get { return 0; } }

        public static char Default_Char { get { return '\0'; } }

        public static DateTime Default_DateTime { get { return new DateTime(1, 1, 1); } }

        public static TimeSpan Default_TimeSpan { get { return new TimeSpan(); } }

        public static decimal Default_Decimal { get { return 0; } }

        public static double Default_Double { get { return 0; } }

        public static float Default_Single { get { return 0; } }

        public static Guid Default_Guid { get { return new Guid(); } }

        public static short Default_Int16 { get { return 0; } }

        public static int Default_Int32 { get { return 0; } }

        public static long Default_Int64 { get { return 0; } }

        public static string Default_String { get { return ""; } }

        #endregion Properties

        #region Methods GetDefault

        // Boolean

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static bool GetDefault(bool value)
        {
            return Default_Boolean;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static bool? GetDefault(bool? value)
        {
            return null;
        }

        // Byte

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static byte GetDefault(byte value)
        {
            return Default_Byte;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static byte? GetDefault(byte? value)
        {
            return null;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static byte[] GetDefault(byte[] value)
        {
            return new byte[] { };
        }

        // Char

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static char GetDefault(char value)
        {
            return Default_Char;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static char? GetDefault(char? value)
        {
            return Default_Char;
        }

        // DateTime

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static DateTime GetDefault(DateTime value)
        {
            return Default_DateTime;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static DateTime? GetDefault(DateTime? value)
        {
            return null;
        }

        // Decimal

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static decimal GetDefault(decimal value)
        {
            return Default_Decimal;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static decimal? GetDefault(decimal? value)
        {
            return null;
        }

        // Double

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static double GetDefault(double value)
        {
            return Default_Double;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static double? GetDefault(double? value)
        {
            return null;
        }

        // Int16

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static short GetDefault(short value)
        {
            return Default_Int16;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static int? GetDefault(short? value)
        {
            return null;
        }

        // Int32

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static int GetDefault(int value)
        {
            return Default_Int32;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static int? GetDefault(int? value)
        {
            return null;
        }

        // Guid

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static Guid GetDefault(Guid value)
        {
            return Default_Guid;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static Guid? GetDefault(Guid? value)
        {
            return null;
        }

        // Int64

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static long GetDefault(long value)
        {
            return Default_Int64;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static long? GetDefault(long? value)
        {
            return null;
        }

        // Single

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static float GetDefault(float value)
        {
            return Default_Single;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static float? GetDefault(float? value)
        {
            return null;
        }

        // String

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static string GetDefault(string value)
        {
            return Default_String;
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns></returns>
        public static string GetDefault(string value, string defaultValue)
        {
            return defaultValue;
        }

        // TimeSpan

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static TimeSpan GetDefault(TimeSpan value)
        {
            return new TimeSpan();
        }

        /// <summary>
        /// Get default.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static TimeSpan? GetDefault(TimeSpan? value)
        {
            return null;
        }

        #endregion Methods GetDefault
    }
}