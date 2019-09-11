using System.Collections;
using System.Collections.Specialized;

namespace EasyLOB.Library
{
    /// <summary>
    /// OrderedDictionary Extensions.
    /// </summary>
    public static class OrderedDictionaryExtensions
    {
        /// <summary>
        /// Get index by key.
        /// </summary>
        /// <param name="orderedDictionary">Ordered Dictionary</param>
        /// <param name="key">Key</param>
        /// <returns>Index</returns>
        public static int GetIndexByKey(this OrderedDictionary orderedDictionary, object key)
        {
            int result = -1;

            if (orderedDictionary.Contains(key))
            {
                int index = 0;
                foreach (DictionaryEntry entry in orderedDictionary)
                {
                    if (entry.Key == key)
                    {
                        result = index;
                        break;
                    }
                    index++;
                }
            }

            return result;
        }

        /// <summary>
        /// Get key by index.
        /// </summary>
        /// <param name="orderedDictionary">Ordered Dictionary</param>
        /// <param name="index">Index</param>
        /// <returns>Key</returns>
        public static object GetKeyByIndex(this OrderedDictionary orderedDictionary, int index)
        {
            object result = null;

            if (index < orderedDictionary.Count)
            {
                int dictionaryIndex = 0;
                foreach (DictionaryEntry entry in orderedDictionary)
                {
                    if (dictionaryIndex == index)
                    {
                        result = entry.Key;
                        break;
                    }
                    dictionaryIndex++;
                }
            }

            return result;
        }

        /// <summary>
        /// Get value by index.
        /// </summary>
        /// <param name="orderedDictionary">Ordered Dictionary</param>
        /// <param name="index">Index</param>
        /// <returns>Value</returns>
        public static object GetValueByIndex(this OrderedDictionary orderedDictionary, int index)
        {
            object result = null;

            if (index < orderedDictionary.Count)
            {
                int dictionaryIndex = 0;
                foreach (DictionaryEntry entry in orderedDictionary)
                {
                    if (dictionaryIndex == index)
                    {
                        result = entry.Value;
                        break;
                    }
                    dictionaryIndex++;
                }

                //object[] values = new object[orderedDictionary.Count];
                //orderedDictionary.Values.CopyTo(values, 0);
                //result = values[index];
            }

            return result;
        }

        /// <summary>
        /// Get value by key.
        /// </summary>
        /// <param name="orderedDictionary">Ordered Dictionary</param>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public static object GetValueByKey(this OrderedDictionary orderedDictionary, object key)
        {
            object result = null;

            if (orderedDictionary.Contains(key))
            {
                result = orderedDictionary[key];

                //foreach (DictionaryEntry entry in orderedDictionary)
                //{
                //    if (entry.Key == key)
                //    {
                //        result = entry.Value;
                //        break;
                //    }
                //}
            }

            return result;
        }
    }
}