using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memcached.ClientLibrary;

namespace Util.Memcached
{
    public class Helper
    {
        public static bool set(string key, object obj, DateTime expiry)
        {
            MemcachedClient mc = new MemcachedClient();
            return mc.Set(key, obj, expiry);
        }

        public static object get(string key)
        {
            MemcachedClient mc = new MemcachedClient();
            return mc.Get(key);
        }

        public static bool Exists(string key)
        {
            MemcachedClient mc = new MemcachedClient();
            return mc.KeyExists(key);
        }

        public static void del(string key)
        {
            MemcachedClient mc = new MemcachedClient();
            mc.Delete(key);
        }
        /// <summary>
        /// 启动memcached
        /// </summary>
        /// <param name="serverlist"></param>
        public static void start(string[] serverlist)
        {
            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);

            pool.InitConnections = 30;
            pool.MinConnections = 30;
            pool.MaxConnections = 50000;

            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;

            pool.MaintenanceSleep = 30;
            pool.Failover = true;

            pool.Nagle = false;
            pool.Initialize();
        }
    }
}
