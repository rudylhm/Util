using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;

namespace Util.Security
{
    /// <summary>
    /// Hmac－SHA1加密助手类
    /// </summary>
    public static class HMACSHA1Util
    {
        /// <summary>
        /// Hmac－SHA1加密
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="encryptKey">加密key</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <returns>加密后的字符串</returns>
        public static string HmacSha1(string sourceString, string encryptKey, LetterCase letterCase = LetterCase.UpperCase)
        {
            if (string.IsNullOrWhiteSpace(sourceString) || string.IsNullOrEmpty(encryptKey)) throw new ArgumentNullException("Empty", "sourceString or encryptKey can't be empty.");

            //构造HMACSHA1对象，并计算哈希值
            HMACSHA1 hmacSHA1 = new HMACSHA1(Encoding.UTF8.GetBytes(encryptKey));
            Byte[] hashString = hmacSHA1.ComputeHash(Encoding.UTF8.GetBytes(sourceString));

            //格式化数据并返回
            StringBuilder sBuilder = new StringBuilder();
            if (letterCase == LetterCase.LowerCase)
            {
                for (Int32 i = 0; i < hashString.Length; i++)
                {
                    sBuilder.Append(hashString[i].ToString("x2"));
                }
            }
            else
            {
                for (Int32 i = 0; i < hashString.Length; i++)
                {
                    sBuilder.Append(hashString[i].ToString("X2"));
                }
            }

            return sBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="encryptKey"></param>
        /// <returns></returns>
        public static byte[] GetHmacSha1ByteArray(string sourceString, string encryptKey)
        {
            if (string.IsNullOrWhiteSpace(sourceString) || string.IsNullOrEmpty(encryptKey)) throw new ArgumentNullException("Empty", "sourceString or encryptKey can't be empty.");

            //构造HMACSHA1对象，并计算哈希值
            HMACSHA1 hmacSHA1 = new HMACSHA1(Encoding.UTF8.GetBytes(encryptKey));
            return hmacSHA1.ComputeHash(Encoding.UTF8.GetBytes(sourceString));
        }

        /// <summary>
        /// SH1加密
        /// </summary>
        /// <param name="str_sha1_in">待加密字符串</param>
        /// <returns></returns>
        public static string SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "");
            return str_sha1_out;
        }
    }
}