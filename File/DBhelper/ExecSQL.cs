using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AGUOPBM.MAModel;
using AGUOPBM.DBUtility;

namespace AGUOPBM.MADPL
{
    public class ExecSQL
    {
        /// <summary>
        /// 获取当前账套数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnStr()
        {
            return SqlHelper.GetConnStr();

            

        }

        /// <summary>
        /// 获取当前账套数据库连接对象
        /// </summary>
        /// <param name="ZTNF">账套年份，空表示当前账套</param>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            return SqlHelper.GetConnection();
        }

        /// <summary>
        /// 检查账套数据库是否能够成功连接
        /// </summary>
        /// <returns></returns>
        public static bool CanConnection()
        {
            bool re = false;
            try
            {
                if (LoginUserInfo.ConnectionMode != "1")
                {

                    SqlConnection con = GetSqlConnection();
                    try
                    {
                        con.Open();
                        con.Close();
                        re = true;
                    }
                    finally
                    {
                        con.Dispose();
                    }

                }
                else
                {
                    re = MAWebService.MyService.A_0();
                    

                }
            }
            catch
            {
                re = false;
            }
            return re;
        }

        /// <summary>
        /// 返回DataSet数据集
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string strSQL)
        {
            //1:WebService连接数据库
            if (LoginUserInfo.ConnectionMode != "1")
                return SqlHelper.ExecuteDataset(SqlHelper.GetConnStr(), CommandType.Text, strSQL);
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(strSQL, datetime); //获取加密后的字符串
                int txtlong = strSQL.Length;  //获取加密前字符串长度

                return MAWebService.MyService.A_A(strTxt, datetime, txtlong);
                

            }

        }

        /// <summary>
        /// 返回DataTable数据集
        /// </summary>
        /// <param name="SQL">sql语句</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string SQL)
        {
            if (LoginUserInfo.ConnectionMode != "1")
                return SqlHelper.ExecuteDataTable(SqlHelper.GetConnStr(), CommandType.Text, SQL);
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(SQL, datetime); //获取加密后的字符串
                int txtlong = SQL.Length;  //获取加密前字符串长度

                return MAWebService.MyService.A_B(strTxt, datetime, txtlong);
               
            }

        }



        /// <summary>
        /// 返回带存储过程参数的DataSet数据集
        /// </summary>
        /// <param name="strProc">存储过程名称</param>
        /// <param name="paramSQL">参数</param>
        /// <returns></returns>
        public static DataSet GetDataSetFromProc(string strProc, SqlParameter[] paramSQL)
        {
            if (LoginUserInfo.ConnectionMode != "1")
                return SqlHelper.ExecuteDataset(SqlHelper.GetConnStr(), CommandType.StoredProcedure, strProc, paramSQL);
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(strProc, datetime); //获取加密后的字符串
                int txtlong = strProc.Length;  //获取加密前字符串长度

                MAWS.SqlParameter[] newPara = MAWebService.GetSqlParameterService(paramSQL); //转换参数数组类型

                return MAWebService.MyService.A_C(strTxt, newPara,  datetime, txtlong);



            }
        }


        /// <summary>
        /// 返整型的SQL执行语句影响记录数
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        public static int ExecuteSQLForInt(string strSQL)
        {
            if (LoginUserInfo.ConnectionMode != "1")
                return SqlHelper.ExecuteNonQuery(SqlHelper.GetConnStr(), CommandType.Text, strSQL);
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(strSQL, datetime); //获取加密后的字符串
                int txtlong = strSQL.Length;  //获取加密前字符串长度

                return MAWebService.MyService.A_D(strTxt, datetime, txtlong);
                
            }
        }

        /// <summary>
        /// 查询数据，返回int（第一行第一列）
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        public static int ExecuteSQLForScalarInt(string strSQL)
        {
            if (LoginUserInfo.ConnectionMode != "1")
                return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnStr(), CommandType.Text, strSQL));
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(strSQL, datetime); //获取加密后的字符串
                int txtlong = strSQL.Length;  //获取加密前字符串长度

                return MAWebService.MyService.A_E(strTxt, datetime, txtlong);
                
            }
        }

        /// <summary>
        /// 查询数据，返回Str（第一行第一列）
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static string ExecuteSQLForScalarStr(string strSQL)
        {
            if (LoginUserInfo.ConnectionMode != "1")
                return SqlHelper.ExecuteScalar(SqlHelper.GetConnStr(), CommandType.Text, strSQL).ToString();
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(strSQL, datetime); //获取加密后的字符串
                int txtlong = strSQL.Length;  //获取加密前字符串长度

                return MAWebService.MyService.A_E2(strTxt, datetime, txtlong);
            }
        }

        /// <summary>
        /// 查询数据，返回int（第一行第一列）
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="paramSQL">参数列表</param>
        public static int ExecuteSQLForScalarInt(string strSQL, SqlParameter[] paramSQL)
        {
            if (LoginUserInfo.ConnectionMode != "1")
                return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.GetConnStr(), CommandType.Text, strSQL, paramSQL));
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(strSQL, datetime); //获取加密后的字符串
                int txtlong = strSQL.Length;  //获取加密前字符串长度

                MAWS.SqlParameter[] newpara = MAWebService.GetSqlParameterService(paramSQL);

                return MAWebService.MyService.A_F(strTxt, newpara, datetime, txtlong);
                


            }
        }

        /// <summary>
        /// 查询数据，返回int（第一行第一列）
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="paramSQL">参数列表</param>
        public static string ExecuteSQLForScalarStr(string strSQL, SqlParameter[] paramSQL)
        {
            if (LoginUserInfo.ConnectionMode != "1")
                return SqlHelper.ExecuteScalar(SqlHelper.GetConnStr(), CommandType.Text, strSQL, paramSQL).ToString();
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(strSQL, datetime); //获取加密后的字符串
                int txtlong = strSQL.Length;  //获取加密前字符串长度

                MAWS.SqlParameter[] newpara = MAWebService.GetSqlParameterService(paramSQL);

                return MAWebService.MyService.A_F2(strTxt, newpara, datetime, txtlong);



            }
        }



        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="strSQL"></param>
        public static void ExecuteSQL(string strSQL)
        {
            if (LoginUserInfo.ConnectionMode != "1")
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnStr(), CommandType.Text, strSQL);
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(strSQL, datetime); //获取加密后的字符串
                int txtlong = strSQL.Length;  //获取加密前字符串长度

                MAWebService.MyService.A_G(strTxt, datetime, txtlong);
                
            }
        }

        
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="paramSQL"></param>
        public static void ExecuteSQL(string strSQL, SqlParameter[] paramSQL)
        {
            if (LoginUserInfo.ConnectionMode != "1")
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnStr(), CommandType.Text, strSQL, paramSQL);
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(strSQL, datetime); //获取加密后的字符串
                int txtlong = strSQL.Length;  //获取加密前字符串长度

                MAWS.SqlParameter[] newpara = MAWebService.GetSqlParameterService(paramSQL);

                //通过WebService调用不会从参数返回对象值，因此只能通过返回值来获取输出参数的值
                MAWS.MyListItem[] list = MAWebService.MyService.A_H(strTxt, newpara, datetime, txtlong);

                if (list != null && paramSQL != null)
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        for (int j = 0; j < paramSQL.Length; j++)
                        {
                            //将输出值存入相同参数名的对象中，使得程序中可对其进行使用
                            if (paramSQL[j].ParameterName == list[i].Text)
                            {
                                paramSQL[j].SqlValue = list[i].Value;
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// 在事务中执行一组SQL语句，成功返回空字符串，错误返回错误原因
        /// </summary>
        /// <param name="listSQL">SQL语句集</param>
        /// <returns></returns>
        public static string ExecuteSQLListForTran(List<string> listSQL)
        {
            string re = "";
            if (LoginUserInfo.ConnectionMode != "1")
            {
                string conStr = ExecSQL.GetConnStr();
                SqlConnection con = new SqlConnection(conStr); //创建数据库连接
                try
                {
                    con.Open();//打开数据库连接

                    SqlCommand command = new SqlCommand(); //创建一个SQL执行命令
                    command.Connection = con; //设置SQL执行命令的数据库连接
                    SqlTransaction myTrans = con.BeginTransaction(); //创建一个数据库事务，并启动数据库连接的事务
                    command.Transaction = myTrans; //指定SQL执行命令所使用的事务

                    try
                    {
                        foreach (string sql in listSQL)
                        {
                            command.CommandText = sql;
                            command.ExecuteNonQuery();
                        }
                        myTrans.Commit();  //提交事务
                        re = "";
                    }
                    catch
                    {
                        myTrans.Rollback();  //事务回滚
                        re = "操作失败！";
                    }
                }
                catch
                {
                    re = "数据库连接失败！";
                }
                finally
                {
                    con.Close(); //关闭数据库连接
                }
            }
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间

                string[] strTxt = new string[listSQL.Count];
                int[] txtlong = new int[listSQL.Count];

                //将所有SQL语句逐条加密并保存到数组中
                //记录每条SQL语句加密前字符串长度记录到数组中
                for (int i = 0; i < listSQL.Count; i++)
                {
                    strTxt[i] = roledal.FPEncryption(listSQL[i], datetime); //获取加密后的字符串
                    txtlong[i] = listSQL[i].Length;  //获取加密前字符串长度
                }

                re = MAWebService.MyService.A_G2(strTxt, datetime, txtlong);


            }
            return re;
        }


        /// <summary>
        /// 执行带参数的存储过程
        /// </summary>
        /// <param name="strProc">存储过程名</param>
        /// <param name="paramSQL">参数</param>
        public static void ExecuteSQLForProc(string strProc, SqlParameter[] paramSQL)
        {
            if (LoginUserInfo.ConnectionMode != "1")
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnStr(), CommandType.StoredProcedure, strProc, paramSQL);

            }
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(strProc, datetime); //获取加密后的字符串
                int txtlong = strProc.Length;  //获取加密前字符串长度

                MAWS.SqlParameter[] newpara = MAWebService.GetSqlParameterService(paramSQL);


                //通过WebService调用不会从参数返回对象值，因此只能通过返回值来获取输出参数的值
                MAWS.MyListItem[] list = MAWebService.MyService.A_I(strTxt, newpara, datetime, txtlong);

                if (list != null && paramSQL != null)
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        for (int j = 0; j < paramSQL.Length; j++)
                        {
                            //将输出值存入相同参数名的对象中，使得程序中可对其进行使用
                            if (paramSQL[j].ParameterName == list[i].Text)
                            {
                                paramSQL[j].SqlValue = list[i].Value;
                            }
                        }
                    }
                }


            }
        }

        /// <summary>
        ///  之行存储过程并返回受影响的行数
        /// </summary>
        /// <param name="strProc">存储过程名</param>
        /// <param name="paramSQL">参数</param>
        /// <returns></returns>
        public static int ExecuteSQLForProcInt(string strProc, SqlParameter[] paramSQL)
        {
            if (LoginUserInfo.ConnectionMode != "1")
                return SqlHelper.ExecuteNonQuery(SqlHelper.GetConnStr(), CommandType.StoredProcedure, strProc, paramSQL);
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(strProc, datetime); //获取加密后的字符串
                int txtlong = strProc.Length;  //获取加密前字符串长度

                MAWS.SqlParameter[] newpara = MAWebService.GetSqlParameterService(paramSQL);

                return MAWebService.MyService.A_J(strTxt, newpara, datetime, txtlong);


            }
        }

        /// <summary>
        /// 执行存储过程并返回数据集
        /// </summary>
        /// <param name="strProc">存储过程名</param>
        /// <param name="paramSQL">参数</param>
        /// <returns></returns>
        public static DataSet ExecuteSQLForProcDataSet(string strProc, SqlParameter[] paramSQL)
        {
            if (LoginUserInfo.ConnectionMode != "1")
                return SqlHelper.ExecuteDataset(SqlHelper.GetConnStr(), CommandType.StoredProcedure, strProc, paramSQL);
            else
            {
                FPRoleDAL roledal = new FPRoleDAL();

                string datetime = roledal.CreateKey();  //获取加密密钥时间
                string strTxt = roledal.FPEncryption(strProc, datetime); //获取加密后的字符串
                int txtlong = strProc.Length;  //获取加密前字符串长度

                MAWS.SqlParameter[] newpara = MAWebService.GetSqlParameterService(paramSQL);

                return MAWebService.MyService.A_K(strTxt, newpara, datetime, txtlong);


            }
        }


        
    }
}
