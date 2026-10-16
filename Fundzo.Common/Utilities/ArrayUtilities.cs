using System;
using System.Collections;
using System.Collections.Generic;

namespace Fundzo.Common.Utilities
{
    public class ArrayUtilities
    {
        public static bool IsEnumerableType(object o)
        {
            return IsEnumerableType(o.GetType());
        }
        public static bool IsEnumerableType(Type type)
        {
            return (type.GetInterface(nameof(IEnumerable)) != null);
        }

        public static int[] ConvertToIntArray(object array)
        {
            List<int> returnList = new List<int>();

            if (array is Newtonsoft.Json.Linq.JArray)
            {
                foreach (var item in array as Newtonsoft.Json.Linq.JArray)
                {
                    returnList.Add(Convert.ToInt32(item));
                }
            }
            else
            {
                // Check if object is array.
                if (array.GetType().IsArray)
                {
                    foreach (var x in array as object[])
                    {
                        if (int.TryParse(x.ToString(), out int result))
                            returnList.Add(result);
                        else
                            throw new InvalidCastException("One or more of the elements in the array are not of type 'int'");
                    }
                }
                else if (IsEnumerableType(array))
                {
                    foreach (var x in (IEnumerable)array)
                    {
                        if (int.TryParse(x.ToString(), out int result))
                            returnList.Add(result);
                        else
                            throw new InvalidCastException("One or more of the elements in the array are not of type 'int'");
                    }
                }
                else
                    throw new ArgumentException("Object is does not implement IEnumerable");

            }

            return returnList.ToArray();
        }
        public static long[] ConvertToLongArray(object array)
        {
            List<long> returnList = new List<long>();

            if (array is Newtonsoft.Json.Linq.JArray)
            {
                foreach (var item in array as Newtonsoft.Json.Linq.JArray)
                {
                    returnList.Add(Convert.ToInt64(item));
                }
            }

            return returnList.ToArray();
        }
    }
}

