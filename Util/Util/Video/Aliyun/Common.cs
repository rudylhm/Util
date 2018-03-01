using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Util.Video.Aliyun
{
    public class Common
    {
        /// <summary>
        /// 通过参数字典生成签名
        /// </summary>
        /// <param name="dict">参数字典</param>
        /// <param name="accessSecret">签名key</param>
        /// <param name="callMethod">接口调用方式(GET/POST)</param>
        /// <returns></returns>
        public static string MakeSign(Dictionary<string, object> dict, string accessSecret, string callMethod)
        {
            string signStr = callMethod.ToUpper() + "&%2F&" + UrlEncodeToUpper(Util.StringCommon.StringHelper.DictToString(Util.StringCommon.StringHelper.DictKeySort(dict), "=", "&", false, null, false, true));
            var byteArray = Security.HMACSHA1Util.GetHmacSha1ByteArray(signStr, accessSecret + "&");
            return Convert.ToBase64String(byteArray);
        }


        public static Dictionary<string, object> MakeDict(Dictionary<string, object> dict, string accessKeyId)
        {
            dict["Format"] = "json";
            dict["Version"] = "2017-03-21";
            dict["SignatureMethod"] = "HMAC-SHA1";
            dict["SignatureVersion"] = "1.0";
            dict["AccessKeyId"] = accessKeyId;
            dict["Timestamp"] = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            dict["SignatureNonce"] = Util.Maths.NumberCommon.GetRandomNumber(99999999);
            return dict;
        }

        public static string UrlEncodeToUpper(string str)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in str)
            {
                if (HttpUtility.UrlEncode(c.ToString()).Length > 1)
                {
                    if (c == ':')
                    {
                        builder.Append(HttpUtility.UrlEncode(HttpUtility.UrlEncode(c.ToString())).ToUpper());
                    }
                    else
                    {
                        builder.Append(HttpUtility.UrlEncode(c.ToString()).ToUpper());
                    }
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }
    }
}
