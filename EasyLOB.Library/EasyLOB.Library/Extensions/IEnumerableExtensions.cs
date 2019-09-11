using System.Collections.Generic;
using System.ComponentModel;

namespace EasyLOB.Library
{
    /// <summary>
    /// IEnumerable Extensions.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Convert IEnumerable{T} to BindingList{T}.
        /// </summary>
        /// <typeparam name="T">Class</typeparam>
        /// <param name="data">IEnumerable</param>
        /// <returns>BindingList</returns>
        public static BindingList<T> MyToBindingList<T>(this IEnumerable<T> data)
        {
            BindingList<T> result = null;
            if (data != null)
            {
                result = new BindingList<T>();
                foreach (T item in data)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        /// <summary>
        /// Convert IEnumerable{T} to List{T}.
        /// </summary>
        /// <typeparam name="T">Class</typeparam>
        /// <param name="data">IEnumerable</param>
        /// <returns>List</returns>
        public static List<T> MyToList<T>(this IEnumerable<T> data)
        {
            List<T> result = null;

            if (data != null)
            {
                result = new List<T>();
                foreach (T item in data)
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}