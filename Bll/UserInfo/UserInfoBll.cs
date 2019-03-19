using Dal.UserInfo;
using Model.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.UserInfo
{
    public class UserInfoBll
    {
        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="name">员工账号</param>
        /// <param name="pwd">员工密码</param>
        /// <returns>返回员工信息</returns>
        public static UserInfoBackGroundModel GetUserinfo(string name , string pwd)
        {
            return UserInfoDal.GetUser(name, pwd);
        }

        /// <summary>
        /// 判断员工的登录时间是否修改成功
        /// </summary>
        /// <param name="name"></param>
        /// <returns>返回值位ture成功否知失败</returns>
        public static bool UpdateUser(string name)
        {
            int a = UserInfoDal.UpdateUser(name);
            if(a==0)
            {
                return false;
            }
            else if(a>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 判断是否注册成功
        /// </summary>
        /// <param name="name">注册账号</param>
        /// <param name="pwd">注册密码</param>
        /// <returns>返回ture成功返回false失败</returns>
        public static bool AddUser(string name, string pwd)
        {
            int a = UserInfoDal.AddUser(name,pwd);
            if(a==0)
            {
                return false;
            }
            else if(a>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
