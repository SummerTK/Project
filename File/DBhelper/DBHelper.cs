using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace FPG.DAL
{
    public class DBHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static string str = "server=.;uid=sa;pwd=sa;database=5Pgo";
        /// <summary>
        /// 链接数据库
        /// </summary>
        private static SqlConnection conn;
        /// <summary>
        /// 执行增删改SQL语句
        /// </summary>
        private static SqlCommand comm;
        /// <summary>
        /// 表
        /// </summary>
        private static DataSet ds;
        /// <summary>
        /// 产生DataSet,更新
        /// </summary>
        private static SqlDataAdapter sda;
        /// <summary>
        /// 打开数据连接
        /// </summary>
        private static void show()
        {
            conn = new SqlConnection(str);
            conn.Open();
        }
        /// <summary>
        /// 增删改方法
        /// </summary>
        /// <param name="sql">增删改sql语句</param>
        /// <returns>是否有影响行数</returns>
        public static bool ExNonQuery(string sql)
        {
            show();
            using (comm = new SqlCommand(sql, conn))
            {
                try
                {
                    return comm.ExecuteNonQuery() > 0;
                }
                catch (Exception e)
                {
                    conn.Close();
                    throw e;
                }
            }
        }
        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="sql">查询sql语句</param>
        /// <returns>查询出来的表</returns>
        public static DataSet Query(string sql)
        {
            show();
            using (sda = new SqlDataAdapter(sql, conn))
            {
                try
                {
                    ds = new DataSet();
                    sda.Fill(ds);
                    return ds;
                }
                catch (Exception e)
                {
                    conn.Close();
                    throw e;
                }
            }
        }

    }
}
