using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Helper
{
    public class MySqlHelper
    {
        public static DataTable ExecuteSql(string sql, DbParameter[] paramterList, string connStr)
        {
            using (var conn = Factory.MysqlFactory.CreateDBConnection(connStr))
            {
                var cmd = Factory.MysqlFactory.CreateDBCommand(sql, conn);
                if (paramterList != null)
                {
                    cmd.Parameters.AddRange(paramterList);
                }
                try
                {
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dataReader);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static int ExecuteSqlReturnEffectRow(string sql, DbParameter[] paramterList, string connStr)
        {
            using (var conn = Factory.MysqlFactory.CreateDBConnection(connStr))
            {
                var cmd = Factory.MysqlFactory.CreateDBCommand(sql, conn);
                if (paramterList != null)
                {
                    cmd.Parameters.AddRange(paramterList);
                }
                try
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
