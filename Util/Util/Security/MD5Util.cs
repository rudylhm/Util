using System;
using System.Text;
using System.Security.Cryptography;

namespace Util.Security
{
    /// <summary>
    /// MD5助手类
    /// </summary>
    public static class MD5Util
    {
        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="letterCase">大小写枚举</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <returns>加密后的字符串</returns>
        public static String MD5(String str, LetterCase letterCase = LetterCase.UpperCase)
        {
            if (String.IsNullOrWhiteSpace(str)) throw new ArgumentNullException("str", "str can't be empty.");

            return MD5(Encoding.UTF8.GetBytes(str), letterCase);
        }

        /// <summary>
        /// 32位大写MD5加密
        /// </summary>
        /// <param name="byteArray">需要加密的字节数组</param>
        /// <param name="letterCase">大小写枚举</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <returns>加密后的字符串</returns>
        public static String MD5(Byte[] byteArray, LetterCase letterCase = LetterCase.UpperCase)
        {
            if (byteArray == null || byteArray.Length == 0) throw new ArgumentNullException("Error", "str can't be empty.");

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                //计算data字节数组的哈希值 
                Byte[] md5data = md5.ComputeHash(byteArray);

                //将加密后的字节数组转换为16进制的字符串
                StringBuilder sBuilder = new StringBuilder();
                if (letterCase == LetterCase.LowerCase)
                {
                    for (Int32 i = 0; i < md5data.Length; i++)
                    {
                        sBuilder.Append(md5data[i].ToString("x2"));
                    }
                }
                else
                {
                    for (Int32 i = 0; i < md5data.Length; i++)
                    {
                        sBuilder.Append(md5data[i].ToString("X2"));
                    }
                }

                return sBuilder.ToString();
            }
        }
    }
}