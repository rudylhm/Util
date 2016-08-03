using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Entity.Factory
{
    public class MysqlFactory
    {
        public static DbConnection CreateDBConnection(string connectString)
        {
            return new MySqlConnection(connectString);
        }

        /// <summary>
        /// 创建DBCommand
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DbCommand CreateDBCommand(string cmdText, DbConnection connection)
        {
            var connObj = connection as MySqlConnection;
            if (connObj == null)
            {
                throw new ArgumentException("Connection对象不正确");
            }
            return new MySqlCommand(cmdText, connObj);
        }

        public static DbParameter CreateDBParameter(string paramName, object value)
        {
            return new MySqlParameter(paramName, value);
        }
    }
}
