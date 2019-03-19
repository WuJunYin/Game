using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DBHelper
{
    /// <summary>
    /// SQL 通用类
    /// Author:Mr_ls
    /// Date:2012-3-10
    /// </summary>
    public class SQLHelper
    {
        /// <summary>
        /// 获取连接对象
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(DBConString.GetSqlStr);
        }

        /// <summary>
        /// 关闭连接对象
        /// </summary>
        /// <param name="con"></param>
        public static void CloseConn(SqlConnection con)
        {
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Dispose();
            }
        }

        /// <summary>
        /// 执行事物处理
        /// </summary>
        /// <param name="cmdStr"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static bool ExecuteTransaction(List<string> cmdStr, List<SqlParameter[]> cmdParams)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    try
                    {
                        con.Open();
                        SqlTransaction tran = con.BeginTransaction();
                        if (cmdStr.Count != cmdParams.Count)
                        {
                            return false;
                        }

                        for (int i = 0; i < cmdStr.Count; i++)
                        {
                            try
                            {
                                ExecuteNonQuery(con, tran, CommandType.Text, cmdStr[i], cmdParams[i]);
                            }
                            catch (Exception)
                            {
                                tran.Rollback();
                                return false;
                            }
                        }

                        tran.Commit();
                        tran.Dispose();
                        return true;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        CloseConn(con);
                    }
                }
            }
        }

        /// <summary>
        /// 执行事物处理
        /// </summary>
        /// <param name="cmdStr"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static bool ExecuteTransaction(List<string> cmdStr, List<SqlParameter[]> cmdParams, out int exsCount)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    try
                    {
                        con.Open();
                        SqlTransaction tran = con.BeginTransaction();
                        exsCount = 0;
                        if (cmdStr.Count != cmdParams.Count)
                        {
                            return false;
                        }

                        for (int i = 0; i < cmdStr.Count; i++)
                        {
                            try
                            {
                                exsCount += ExecuteNonQuery(con, tran, CommandType.Text, cmdStr[i], cmdParams[i]);
                            }
                            catch (Exception)
                            {
                                tran.Rollback();
                                return false;
                            }
                        }

                        tran.Commit();
                        tran.Dispose();
                        return true;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        CloseConn(con);
                    }
                }
            }
        }

        /// <summary>
        /// 执行通用增、删、改方法
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdStr"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        private static int ExecuteNonQuery(SqlTransaction sqlTran, CommandType cmdType, string cmdStr, SqlParameter[] cmdParams)
        {
            return ExecuteNonQuery(GetConnection(), sqlTran, cmdType, cmdStr, cmdParams);
        }

        public static int ExecuteNonQuery(SqlConnection con, SqlTransaction sqlTran, CommandType cmdType, string cmdStr, SqlParameter[] cmdParams)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    ParamCommand(con, cmd, cmdType, sqlTran, cmdStr, cmdParams);
                    int result = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return result;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    if (sqlTran == null)
                    {
                        CloseConn(con);
                    }
                }
            }
        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdStr, SqlParameter[] cmdParams)
        {
            return ExecuteNonQuery(null, cmdType, cmdStr, cmdParams);
        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdStr)
        {
            return ExecuteNonQuery(cmdType, cmdStr, null);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdStr"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdStr, SqlParameter[] cmdParams)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        ParamCommand(con, cmd, cmdType, null, cmdStr, cmdParams);
                        object result = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        return result;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        CloseConn(con);
                    }
                }
            }
        }

        public static object ExecuteScalar(CommandType cmdType, string cmdStr)
        {
            return ExecuteScalar(CommandType.Text, cmdStr, null);
        }

        /// <summary>
        /// 查询返回结果
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdStr"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static DataTable ExecuteTable(CommandType cmdType, string cmdStr, SqlParameter[] cmdParams)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        ParamCommand(con, cmd, cmdType, null, cmdStr, cmdParams);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        DataTable dt = new DataTable("Table");
                        da.Fill(dt);
                        cmd.Parameters.Clear();

                        return dt;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        CloseConn(con);
                    }
                }
            }
        }

        /// <summary>
        /// 查询返回结果集
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdStr"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdStr, SqlParameter[] cmdParams)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        ParamCommand(con, cmd, cmdType, null, cmdStr, cmdParams);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        cmd.Parameters.Clear();

                        return ds;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        CloseConn(con);
                    }
                }
            }
        }

        /// <summary>
        /// 查询返回结果集
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdStr"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdStr)
        {
            return ExecuteDataSet(cmdType, cmdStr, null);
        }
        public static DataTable ExecuteTable(CommandType cmdType, string cmdStr)
        {
            return ExecuteTable(cmdType, cmdStr, null);
        }

        /// <summary>
        /// 执行SqlCommand对象赋值
        /// </summary>
        /// <param name="con"></param>
        /// <param name="cmd"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdStr"></param>
        /// <param name="cmdParams"></param>
        public static void ParamCommand(SqlConnection con, SqlCommand cmd, CommandType cmdType, SqlTransaction sqlTran, string cmdStr, SqlParameter[] cmdParams)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.Connection = con;
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdStr;

            if (sqlTran != null)
            {
                cmd.Transaction = sqlTran;
            }

            if (cmdParams != null)
            {
                foreach (SqlParameter parm in cmdParams)
                {
                    if (parm != null)
                    {
                        //2012-03-26 Update 升级  Author:Mr_Ls  解决数据库可以为空字段而参数必须非null值现象
                        if (parm.Value == null)
                        {
                            parm.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(parm);
                    }
                }
            }

        }
    }
}
