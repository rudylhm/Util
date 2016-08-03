using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Factory
{
    public class SQLServer
    {
        public static DbConnection CreateDBConnection(string connectString)
        {
            return new SqlConnection(connectString);
        }

        /// <summary>
        /// 创建DBCommand
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DbCommand CreateDBCommand(string cmdText, DbConnection connection)
        {
            SqlConnection connObj = connection as SqlConnection;
            if (connObj == null)
            {
                throw new ArgumentException("Connection对象不正确");
            }
            return new SqlCommand(cmdText, connObj);
        }

        public static DbParameter CreateDBParameter(string paramName, object value)
        {
            return new SqlParameter(paramName, value);
        }
    }
}
