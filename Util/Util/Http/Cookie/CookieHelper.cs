using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Util.Http.Cookie
{
    /// <summary>
    /// Cookie操作类
    /// </summary>
    public class CookieHelper
    {
        /// <summary>
        /// 添加或修改cookie值
        /// </summary>
        /// <param name="title">键</param>
        /// <param name="name">子键</param>
        /// <param name="value">cookie值</param>
        /// <param name="expireTime">超时时间</param>
        /// <returns>是否成功</returns>
        public static bool AddOrUpdateCookies(string title, string name, string value, DateTime expireTime)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(title);
                cookie.Value = value;
                if (HttpContext.Current.Request.Cookies[title][name] == null)
                {
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    return true;
                }
                else
                {
                    HttpContext.Current.Response.Cookies.Set(cookie);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 添加或修改cookie值
        /// </summary>
        /// <param name="title">键</param>
        /// <param name="name">子键</param>
        /// <param name="value">cookie值</param>
        /// <param name="minutes">超时分钟数</param>
        /// <returns>是否成功</returns>
        public static bool AddOrUpdateCookiesExpireMinute(string title, string name, string value, int minutes)
        {
            return AddOrUpdateCookies(title, name, value, DateTime.Now.AddMinutes(minutes));
        }

        /// <summary>
        /// 添加或修改cookie值
        /// </summary>
        /// <param name="title">键</param>
        /// <param name="name">子键</param>
        /// <param name="value">cookie值</param>
        /// <param name="months">超时月份数</param>
        /// <param name="days">超时天数</param>
        /// <param name="hours">超时小时数</param>
        /// <param name="minutes">超时分钟数</param>
        /// <param name="seconds">超时秒数</param>
        /// <returns>是否成功</returns>
        public static bool AddOrUpdateCookies(string title, string name, string value, int months, int days, int hours, int minutes, int seconds)
        {
            return AddOrUpdateCookies(title, name, value, DateTime.Now.AddMonths(months).AddDays(days).AddHours(hours).AddMinutes(minutes).AddSeconds(seconds));
        }

        /// <summary>
        /// 添加或修改cookie值
        /// </summary>
        /// <param name="name">子键</param>
        /// <param name="value">cookie值</param>
        /// <param name="expireTime">超时时间</param>
        /// <returns>是否成功</returns>
        public static bool AddOrUpdateCookies(string name, string value, DateTime expireTime)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = value;
                if (HttpContext.Current.Request.Cookies[name] == null)
                {
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    return true;
                }
                else
                {
                    HttpContext.Current.Response.Cookies.Set(cookie);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 添加或修改cookie值
        /// </summary>
        /// <param name="name">子键</param>
        /// <param name="value">cookie值</param>
        /// <param name="minutes">超时分钟数</param>
        /// <returns>是否成功</returns>
        public static bool AddOrUpdateCookiesExpireMinute(string name, string value, int minutes)
        {
            return AddOrUpdateCookies(name, value, DateTime.Now.AddMinutes(minutes));
        }

        /// <summary>
        /// 添加或修改cookie值
        /// </summary>
        /// <param name="name">子键</param>
        /// <param name="value">cookie值</param>
        /// <param name="months">超时月份数</param>
        /// <param name="days">超时天数</param>
        /// <param name="hours">超时小时数</param>
        /// <param name="minutes">超时分钟数</param>
        /// <param name="seconds">超时秒数</param>
        /// <returns>是否成功</returns>
        public static bool AddOrUpdateCookies(string name, string value, int months, int days, int hours, int minutes, int seconds)
        {
            return AddOrUpdateCookies(name, value, DateTime.Now.AddMonths(months).AddDays(days).AddHours(hours).AddMinutes(minutes).AddSeconds(seconds));
        }

        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <param name="title">键</param>
        /// <param name="name">子键</param>
        /// <returns>键值</returns>
        public static string GetCookie(string title, string name)
        {
            return HttpContext.Current.Request.Cookies[title][name];
        }

        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <param name="title">键</param>
        /// <param name="name">子键</param>
        /// <returns>键值</returns>
        public static string GetCookie(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                return HttpContext.Current.Request.Cookies[name].Value;
            }
            return null;
        }

    }
}
