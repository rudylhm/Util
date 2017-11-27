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
        private static List<string> letterArray = new List<string>()
        {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"
        };

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
        /// 将字典的key值将按字母顺序排序
        /// </summary>
        /// <param name="dict">待排序字典</param>
        /// <returns>排序后字典</returns>
        public static Dictionary<string, object> DictValueSort(Dictionary<string, object> dict)
        {
            return dict.OrderBy(item => item.Value).ToDictionary(key => key.Key, value => value.Value);
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

        /// <summary>
        /// 限制显示的字符数长度(超长后用hideReplaceCount个filledStr代替)
        /// </summary>
        /// <param name="resourceStr">原始字符串</param>
        /// <param name="showCount">显示的最长字符串</param>
        /// <param name="hideReplaceCount">显示替代字符串长度</param>
        /// <param name="filledStr">替代的字符串</param>
        /// <returns></returns>
        public static string LimitShowStringLength(string resourceStr, int showCount, int hideReplaceCount = 3, string filledStr = ".")
        {
            if (resourceStr.Length > showCount)
            {
                if (showCount <= hideReplaceCount)
                {
                    throw new ArgumentException("隐藏的字符串不能大于显示的字符串长度");
                }
                resourceStr = resourceStr.Substring(0, showCount - hideReplaceCount);
                for (int i = 0; i < hideReplaceCount; i++)
                {
                    resourceStr += filledStr;
                }
            }
            return resourceStr;
        }

        /// <summary>
        /// 将字符串中间的字符用X个替换字符显示
        /// </summary>
        /// <param name="resourceStr">原始字符串</param>
        /// <param name="frontShowCount">字符串前段展示字符数</param>
        /// <param name="bottomShowCount">字符串尾段展示字符数</param>
        /// <param name="hideReplaceCount">隐藏的部分用几个替换字符显示</param>
        /// <param name="replaceStr">隐藏字符显示字符串(默认为*)</param>
        /// <returns>生成的隐藏中间部分字符</returns>
        public static string SubMiddleStringChar(string resourceStr, int frontShowCount, int bottomShowCount, int hideReplaceCount, string replaceStr = "*")
        {
            int resourceLength = resourceStr.Length;
            if (frontShowCount + bottomShowCount >= resourceLength)
            {
                return resourceStr;
            }
            string frontTargetStr = resourceStr.Substring(0, frontShowCount);
            string bottomTargetStr = resourceStr.Substring(resourceLength - bottomShowCount, bottomShowCount);
            string midTargetStr = string.Empty;
            for (int i = 0; i < hideReplaceCount; i++)
            {
                midTargetStr += replaceStr;
            }
            return frontTargetStr + midTargetStr + bottomTargetStr;
        }

        /// <summary>
        /// 将以分为单位的价格转换为以元为单位(不带￥符号)
        /// </summary>
        /// <param name="price">价格</param>
        /// <returns></returns>
        public static string FenPriceToYuan(string price)
        {
            return price.Substring(0, price.Length - 2) + "." + price.Substring(price.Length - 2, 2);
        }

        /// <summary>
        /// 将以分为单位的价格转换为以元为单位(不带￥符号)
        /// </summary>
        /// <param name="price">价格</param>
        /// <returns></returns>
        public static string FenPriceToYuan(int price)
        {
            return FenPriceToYuan(price.ToString("D3"));
        }

        /// <summary>
        /// 将阿拉伯数字转为文字数字
        /// </summary>
        /// <param name="number">阿拉伯数字</param>
        /// <returns></returns>
        public static string NumberToChinese(int number)
        {
            string res = string.Empty;
            string str = number.ToString();
            string schar = str.Substring(0, 1);
            switch (schar)
            {
                case "1":
                    res = "一";
                    break;
                case "2":
                    res = "二";
                    break;
                case "3":
                    res = "三";
                    break;
                case "4":
                    res = "四";
                    break;
                case "5":
                    res = "五";
                    break;
                case "6":
                    res = "六";
                    break;
                case "7":
                    res = "七";
                    break;
                case "8":
                    res = "八";
                    break;
                case "9":
                    res = "九";
                    break;
                default:
                    res = "零";
                    break;
            }
            if (str.Length > 1)
            {
                switch (str.Length)
                {
                    case 2:
                    case 6:
                        res += "十";
                        break;
                    case 3:
                    case 7:
                        res += "百";
                        break;
                    case 4:
                        res += "千";
                        break;
                    case 5:
                        res += "万";
                        break;
                    default:
                        res += "";
                        break;
                }
                res += NumberToChinese(int.Parse(str.Substring(1, str.Length - 1)));
            }
            return res;
        }

        /// <summary>
        /// 获取对应索引的字母
        /// </summary>
        /// <param name="index">索引(范围:1~26)</param>
        /// <returns></returns>
        public static string GetIndexLetter(int index)
        {
            index -= 1;
            if (index < 0 || index > 25)
            {
                return null;
            }
            return letterArray[index];
        }
    }
}
