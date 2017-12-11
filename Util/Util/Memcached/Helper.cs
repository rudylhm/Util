using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memcached.ClientLibrary;

namespace Util.Memcached
{
    public class Helper
    {
        public static string defaultPoolName = "default";

        public static bool Set(string key, object obj, DateTime expiry)
        {
            MemcachedClient mc = new MemcachedClient();
            mc.PoolName = defaultPoolName;
            mc.EnableCompression = false;
            return mc.Set(key, obj, expiry);
        }

        public static T Get<T>(string key) where T : class
        {
            MemcachedClient mc = new MemcachedClient();
            mc.PoolName = defaultPoolName;
            mc.EnableCompression = false;
            return mc.Get(key) as T;
        }

        public static List<T> Gets<T>(string[] keyArray)
        {
            MemcachedClient mc = new MemcachedClient();
            mc.PoolName = defaultPoolName;
            mc.EnableCompression = false;
            var objList = mc.GetMultipleArray(keyArray);
            List<T> resultList = new List<T>();
            foreach (var obj in objList)
            {
                if (obj is T result)
                {
                    resultList.Add(result);
                }
            }
            return resultList;
        }

        public static bool Exists(string key)
        {
            MemcachedClient mc = new MemcachedClient();
            mc.PoolName = defaultPoolName;
            mc.EnableCompression = false;
            return mc.KeyExists(key);
        }

        public static bool Del(string key)
        {
            MemcachedClient mc = new MemcachedClient();
            mc.PoolName = defaultPoolName;
            mc.EnableCompression = false;
            return mc.Delete(key);
        }
        /// <summary>
        /// 启动memcached
        /// </summary>
        /// <param name="serverlist"></param>
        public static void Start(string[] serverlist, string poolName)
        {
            defaultPoolName = poolName;
            //初始化池
            SockIOPool pool = SockIOPool.GetInstance(defaultPoolName);
            pool.SetServers(serverlist);

            pool.InitConnections = 30;
            pool.MinConnections = 15;
            pool.MaxConnections = 50000;

            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;

            pool.MaintenanceSleep = 30;
            pool.Failover = true;

            pool.Nagle = false;
            pool.Initialize();
        }

        private static T ObjectConverter<T>(object obj) where T : class
        {
            return obj as T;
        }
    }
}
