using DBHelper;
using Model.UserInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.UserInfo
{
    public class UserInfoDal
    {
        /// <summary>
        /// 获取后台员工信息
        /// </summary>
        /// <param name="id">后台员工账号</param>
        /// <param name="pwd">后台员工密码</param>
        /// <returns>返回员工账号和密码</returns>
        public static UserInfoBackGroundModel GetUser(string name, string pwd)
        {
            string user_sql = "select * from Tab_UserLogin where UserName = @name and UserPwd = @pwd";
            SqlParameter[] pars = {
                new SqlParameter("@name",name),
                new SqlParameter("@pwd",pwd)
            };
            DataTable user_table = SQLHelper.ExecuteTable(CommandType.Text, user_sql, pars);
            UserInfoBackGroundModel userone = null;
            if (user_table.Rows.Count > 0)
            {
                userone = new UserInfoBackGroundModel();
                userone.UserName = user_table.Rows[0]["UserName"].ToString();
                userone.UserPwd = user_table.Rows[0]["UserPwd"].ToString();
            }
            return userone;
        }


        /// <summary>
        /// 修改员工的登录时间
        /// </summary>
        /// <param name="name">员工账号</param>
        /// <returns>返回受影响的行数</returns>
        public static int UpdateUser(string name)
        {
            SqlConnection con = SQLHelper.GetConnection();
            string sqlone = "update Tab_UserLogin set User_Time = @time where UserName = @name";
            SqlParameter[] pars = {
                new SqlParameter("@name",name),
                new SqlParameter("@time",DateTime.Now)
            };
            return SQLHelper.ExecuteNonQuery(CommandType.Text,sqlone,pars);
        }

       /// <summary>
       /// 添加新用户
       /// </summary>
       /// <param name="name">注册账号</param>
       /// <param name="pwd">注册密码</param>
       /// <returns>返回受影响的行数</returns>
        public static int AddUser(string name, string pwd)
        {
            int a = 0;
            string sqltwo = "select * from Tab_UserLogin where UserName = @name";
            SqlParameter[] parstwo = { new SqlParameter("@name", name) };
            if (SQLHelper.ExecuteScalar(CommandType.Text, sqltwo, parstwo)!=null)
            {
                return a;//测试代表用户已存在
            }
            else
            {
                string sqlone = "insert into Tab_UserLogin (UserName,User_Time,UserPwd)values(@name,@time,@pwd)";
                SqlParameter[] pars = {
                new SqlParameter("@name",name),
                new SqlParameter("@time",DateTime.Now),
                new SqlParameter("@pwd",pwd)
                };

                return SQLHelper.ExecuteNonQuery(CommandType.Text, sqlone, pars);
            }
            
        }
    }
}
