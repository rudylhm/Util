using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Text;
using System.Collections.Generic;

namespace Util.Http.Security
{
    public class HttpFormDecryptModule : IHttpModule
    {
        #region IHttpModule 成员

        public bool isEnableHttpEncrypt;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        private static string _formKey = "encryptFormKey";
        private static void AddItem(string key, string value)
        {
            if (!HttpContext.Current.Items.Contains(_formKey))
            {
                HttpContext.Current.Items[_formKey] = new Dictionary<string, string>();
            }

            var cacheKey = key.ToLower();
            ((Dictionary<string, string>)HttpContext.Current.Items[_formKey])[cacheKey] = value;
        }


        public static string GetItem(string key)
        {
            if (HttpContext.Current.Items.Contains(_formKey))
            {
                var cacheKey = key.ToLower();
                var cache = ((Dictionary<string, string>)HttpContext.Current.Items[_formKey]);
                if (cache.ContainsKey(cacheKey))
                {
                    return cache[cacheKey];
                }
            }

            return string.Empty;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            if (isEnableHttpEncrypt)
            {
                if (HttpContext.Current.Request.Headers.AllKeys.Contains("NODescryptInputStream")
                    ||
                    !HttpContext.Current.Request.Url.OriginalString.Contains(".aspx")
                    )
                {
                    return;
                }

                var inputString = Spanner.GetRequestInputStream(Encoding.UTF8, false);
                if (!string.IsNullOrEmpty(inputString))
                {
                    try
                    {
                        //var source = MoqiEncryptMgr.DecryptDataWithBase64(inputString, EncryptKey);
                        //var items = Spanner.SpliteStringsClearEmpty(source, "&");

                        //foreach (var item in items)
                        //{
                        //    var infos = Spanner.SpliteStringsClearEmpty(item, "=");
                        //    if (infos.Length == 2)
                        //    {
                        //        AddItem(infos[0], HttpUtility.UrlDecode(infos[1]));
                        //    }
                        //}
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public static readonly string EncryptKey;
        #endregion
    }
}
