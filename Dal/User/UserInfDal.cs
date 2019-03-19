using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.User
{
    public class UserInfDal
    {
        /// <summary>
        /// 分页查数据
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="row">每页数</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public static DataSet GetProductByStr(int page, int row, string where)
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("select count(1) from TUsers inner join TUserInfo on TUsers.UserID = TUserInfo.UserID where 1=1 {0};", where);
            str.AppendFormat(@"select T.* from(select TUsers.UserID,TUsers.userName,TUsers.NickName,TUserInfo.WalletMoney,TUserInfo.VipLevel,TUserInfo.VipeTime,ROW_NUMBER()over(order by TUsers.UserID)rw from TUsers inner join TUserInfo on TUsers.UserID = TUserInfo.UserID where 1=1 {2})T where T.rw between {0} and {1}", (page - 1) * row + 1, page * row, where);
            DataSet ds = SQLHelper.ExecuteDataSet(CommandType.Text, str.ToString());
            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page">当前页数</param>
        /// <param name="row">每页数</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public static DataSet GetUserMoneyChange(int page, int row, string where)
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("select count(1) from Web_MoneyChangeLog inner join TUsers on Web_MoneyChangeLog.UserID = TUsers.UserID where 1=1 {0};", where);
            str.AppendFormat("select T.* from (select Web_MoneyChangeLog.UserID,Web_MoneyChangeLog.UserName,Web_MoneyChangeLog.StartMoney,Web_MoneyChangeLog.ChangeMoney,Web_MoneyChangeLog.ChangeType,Web_MoneyChangeLog.DateTime ,Web_MoneyChangeLog.Remark,Web_MoneyChangeLog.RoomID,Web_MoneyChangeLog.QunNum,Web_MoneyChangeLog.RoomCardNum,Web_MoneyChangeLog.Riqi,ROW_NUMBER() over(order by Web_MoneyChangeLog.UserID)rw from Web_MoneyChangeLog inner join TUsers on Web_MoneyChangeLog.UserID = TUsers.UserID where 1=1 {2})T where  T.rw between {0} and {1}", (page - 1) * row + 1, page * row, where);
            DataSet dt = SQLHelper.ExecuteDataSet(CommandType.Text,str.ToString());
            return dt;
        }
    }
}
