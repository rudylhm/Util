using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Maths
{
    /*
    * 创建人：Rudy.Liu
    * 创建时间：2014/7/1 17:16:41
    * 功能：
    */
    public class DateTimeCommon
    {
        private static readonly long timeStampTicks = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).Ticks;

        private static readonly long rechargeStampTicks = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2015, 1, 1)).Ticks;

        /// <summary>
        /// 将时间转换为时间戳(单位秒)
        /// </summary>
        /// <param name="dt">要转换的时间</param>
        /// <returns></returns>
        public static long ConvertToTimeStamp(DateTime dt)
        {
            if (dt == null)
            {
                return 0;
            }
            return (dt.Ticks - timeStampTicks) / (1000 * 10000);
        }

        /// <summary>
        /// 将时间转换为时间戳(单位毫秒)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long ConvertToTimeStampMilliseconds(DateTime dt)
        {
            if (dt == null)
            {
                return 0;
            }
            return (dt.Ticks - timeStampTicks) / (10000);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long Recharge_ConvertToTimeStampMilliseconds(DateTime dt)
        {
            if (dt == null)
            {
                return 0;
            }
            return (dt.Ticks - rechargeStampTicks) / (10000);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minuendDate">被减数</param>
        /// <param name="subtrahendDate">减数</param>
        /// <returns></returns>
        public static long CalIntervalMilliseconds(DateTime minuendDate, DateTime subtrahendDate)
        {
            TimeSpan span = minuendDate - subtrahendDate;
            return span.Ticks / 10000;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minuendDate">被减数</param>
        /// <param name="subtrahendDate">减数</param>
        /// <returns></returns>
        public static int CalIntervalDay(DateTime minuendDate, DateTime subtrahendDate)
        {
            var milliseconds = CalIntervalMilliseconds(minuendDate, subtrahendDate);
            return Convert.ToInt32(milliseconds / 1000 / 60 / 60 / 24);
        }
    }
}
