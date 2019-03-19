using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DBHelper
{
    /// <summary>
    /// 数据库连接字符串类
    /// Author:Mr_Ls
    /// Date:2012-3-10
    /// </summary>
    public class DBConString
    {
        /// <summary>
        /// 获取SQL连接字符串
        /// </summary>
        public static string GetSqlStr
        {
            get {

                return ConfigurationManager.ConnectionStrings["SqlStr"].ConnectionString;
            }
        }
    }
}
