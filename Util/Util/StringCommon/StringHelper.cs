using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.StringCommon
{
    /*
    * 创建人：Rudy.Liu
    * 创建时间：2014/11/4 12:03:13
    * 功能：
    */
    public class StringHelper
    {
        public static List<int> AutoSplitStringListToIntList(string stringList, char splitChar = ',')
        {
            List<int> resultList = new List<int>();
            if (string.IsNullOrEmpty(stringList))
            {
                return resultList;
            }
            string[] strList = stringList.Split(splitChar);
            foreach (string str in strList)
            {
                int i_str;
                if (int.TryParse(str, out i_str))
                {
                    resultList.Add(i_str);
                }
            }
            return resultList;
        }

        public static string MakeRandomString(int lengh)
        {
            string str = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_";//75个字符
            string result = string.Empty;
            for (int i = 0; i < lengh; i++)
            {
                int m = Maths.NumberCommon.GetRandomNumber(str.Length - 1);//这里下界是0，随机数可以取到，上界应该是75，因为随机数取不到上界，也就是最大74，符合我们的题意
                string s = str.Substring(m, 1);
                result += s;
            }
            return result;
        }

        /// <summary>
        /// Dictionary(string,string)转为string字符串(重载)
        /// </summary>
        /// <param name="dictionary">待转换字典</param>
        /// <param name="splitChar">各个键值对之间的分隔符</param>
        /// <returns>转换后的string</returns>
        public static string DictToString(Dictionary<string, object> dictionary, string splitChar)
        {
            return DictToString(dictionary, "=", splitChar, false, new List<string>(), false);
        }

        /// <summary>
        /// Dictionary(string,string)转为string字符串(重载)
        /// </summary>
        /// <param name="dictionary">待转换字典</param>
        /// <param name="splitChar">各个键值对之间的分隔符</param>
        /// <param name="valueHasQuotes">值是否要加双引号(eg.为true: a="123",为 false: a=123)</param>
        /// <returns>转换后的string</returns>
        public static string DictToString(Dictionary<string, object> dictionary, string splitChar, bool valueHasQuotes)
        {
            return DictToString(dictionary, "=", splitChar, valueHasQuotes, new List<string>(), false);
        }

        /// <summary>
        /// Dictionary(string,string)转为string字符串(重载)
        /// </summary>
        /// <param name="dictionary">待转换字典</param>
        /// <param name="splitChar">各个键值对之间的分隔符</param>
        /// <param name="valueHasQuotes">值是否要加双引号(eg.为true: a="123",为 false: a=123)</param>
        /// <param name="ignoreKeyList">需要忽略的key列表,类型为List(string)</param>
        /// <param name="isSpellValueOnly">是否只拼接value(eg. 为false:a=123,b=456, 为true:123,456)</param>
        /// <returns>拼接后的字符串</returns>
        public static string DictToString(Dictionary<string, object> dictionary, string splitChar, bool valueHasQuotes, List<string> ignoreKeyList, bool isSpellValueOnly)
        {
            return DictToString(dictionary, "=", splitChar, valueHasQuotes, ignoreKeyList, isSpellValueOnly);
        }

        /// <summary>
        /// Dictionary(string,string)转为string字符串
        /// </summary>
        /// <param name="dictionary">字典</param>
        /// <param name="keyValueSplitChar">key与value直间的连接串</param>
        /// <param name="splitChar">键值对之间的连接字符</param>
        /// <param name="valueHasQuotes">值是否需要双引号</param>
        /// <param name="ignoreKeyList">需要忽略的key列表</param>
        /// <param name="isSpellValueOnly">是否只拼接value(eg. 为false:a=123,b=456, 为true:123,456)</param>
        /// <param name="ignoreNullOrEmptyValue">若key对应的Value为空时是否忽略该键值对</param>
        /// <returns>拼接后的字符串</returns>
        public static string DictToString(Dictionary<string, object> dictionary, string keyValueSplitChar, string splitChar, bool valueHasQuotes, List<string> ignoreKeyList, bool isSpellValueOnly, bool ignoreNullOrEmptyValue = false)
        {
            var sb = new StringBuilder();

            string quote = string.Empty;
            if (valueHasQuotes)
            {
                quote = "\"";
            }

            foreach (var key in dictionary.Keys)
            {
                bool isFindKey = false;
                if (ignoreKeyList != null)
                {
                    foreach (string str in ignoreKeyList)
                    {
                        if (key == str)
                        {
                            isFindKey = true;
                            break;
                        }
                    }
                }
                if (!isFindKey)
                {
                    var value = dictionary[key];
                    if (value != null && (!ignoreNullOrEmptyValue || value.ToString() != string.Empty))
                    {

                        if (!isSpellValueOnly)
                        {
                            sb.Append(key + keyValueSplitChar + quote + value.ToString() + quote + splitChar);
                        }
                        else
                        {
                            sb.Append(quote + value.ToString() + quote + splitChar);
                        }
                    }
                }
            }
            return sb.ToString().TrimEnd(splitChar.ToCharArray());
        }

        /// <summary>
        /// 将字典的key值将按字母顺序排序
        /// </summary>
        /// <param name="dict">待排序字典</param>
        /// <returns>排序后字典</returns>
        public static Dictionary<string, object> DictKeySort(Dictionary<string, object> dict)
        {
            return dict.OrderBy(item => item.Key).ToDictionary(key => key.Key, value => value.Value);
        }

        /// <summary>
        /// 隐藏字符串中间的字符
        /// </summary>
        /// <param name="resourceStr">原始字符串</param>
        /// <param name="frontShowCount">字符串前段展示字符数</param>
        /// <param name="bottomShowCount">字符串尾段展示字符数</param>
        /// <param name="replaceStr">隐藏字符显示字符串(默认为*)</param>
        /// <returns>生成的隐藏中间部分字符</returns>
        public static string HideMiddleStringChar(string resourceStr, int frontShowCount, int bottomShowCount, string replaceStr = "*")
        {
            int resourceLength = resourceStr.Length;
            if (resourceLength < frontShowCount || resourceLength < bottomShowCount)
            {
                throw new ArgumentException("字符串长度小于要展示的长度");
            }
            string frontTargetStr = resourceStr.Substring(0, frontShowCount);
            string bottomTargetStr = resourceStr.Substring(resourceLength - bottomShowCount, bottomShowCount);
            string midTargetStr = string.Empty;
            for (int i = 0; i < resourceLength - frontShowCount - bottomShowCount; i++)
            {
                midTargetStr += replaceStr;
            }
            return frontTargetStr + midTargetStr + bottomTargetStr;
        }

    }
}
