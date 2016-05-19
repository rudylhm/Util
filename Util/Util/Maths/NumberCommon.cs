using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Maths
{
    /*
    * 创建人：Rudy.Liu
    * 创建时间：2014/6/21 15:13:34
    * 功能：
    */
    public class NumberCommon
    {
        private static Random random = new Random();

        /// <summary>
        /// 获取0~max的整形随机数(包含max)
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandomNumber(int max)
        {
            return random.Next(1, max + 1);
        }

        public static int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public static bool IsNum(string str)
        {
            int temp = 0;
            if (int.TryParse(str, out temp))
            {
                return true;
            }
            return false;
        }
    }
}
