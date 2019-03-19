using Common;
using Dal.User;
using Model.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.User
{
    public class UserInfoBll
    {
        /// <summary>
        /// 分页查数据
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="row">每页数</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public static List<UserInfoModel.userModel> GetProductByStr(int page, int row, string where, out int allrow) {
            DataSet ds = UserInfDal.GetProductByStr(page, row, where.ToString());
            allrow = 0;
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                allrow = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            List<UserInfoModel.userModel> list = new List<UserInfoModel.userModel>();
            if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows) {
                    UserInfoModel.userModel userModel = new UserInfoModel.userModel();
                    userModel.UserID = dr["UserID"].ToString().ToInt();
                    userModel.NickName = dr["NickName"].ToString();
                    userModel.userName = dr["userName"].ToString();
                    userModel.VipeTime = dr["VipeTime"].ToString().ToDateTime();
                    userModel.VipLevel = dr["VipLevel"].ToString().ToInt();
                    userModel.WalletMoney = dr["WalletMoney"].ToString().ToInt();
                    list.Add(userModel);
                }
            }
            return list;
        }


        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="page">当前页数</param>
        /// <param name="row">每页数目</param>
        /// <param name="where">查询条件</param>
        /// <param name="allrow">第一张表一共有多少列</param>
        /// <returns></returns>
        public static List<UserChangeMoney.UserMoney> GetUserMoney(int page, int row,string where ,out int allrow)
        {
            DataSet ds = UserInfDal.GetUserMoneyChange(page,row,where.ToString());
            allrow = 0;
            if(ds.Tables[0]!=null && ds.Tables[0].Rows.Count>0)
            {
                allrow = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            List<UserChangeMoney.UserMoney> list = new List<UserChangeMoney.UserMoney>();
            if(ds.Tables[1]!=null && ds.Tables[1].Rows.Count>0)
            {
                foreach(DataRow dr in ds.Tables[1].Rows)
                {
                    UserChangeMoney.UserMoney usermoney_new = new UserChangeMoney.UserMoney();
                    usermoney_new.UserID = Int32.Parse(dr["UserID"].ToString());
                    usermoney_new.UserName = dr["UserName"].ToString();
                    usermoney_new.StartMoney = decimal.Parse(dr["StartMoney"].ToString());
                    usermoney_new.ChangeMoney = decimal.Parse(dr["ChangeMoney"].ToString()) ;
                    usermoney_new.ChangeType = Int32.Parse(dr["ChangeType"].ToString());
                    usermoney_new.DateTime= DateTime.Parse(dr["DateTime"].ToString()) ;
                    usermoney_new.Remark= dr["Remark"].ToString();
                    usermoney_new.RoomID= Int32.Parse(dr["RoomID"].ToString()) ;
                    usermoney_new.QunNum= Int32.Parse(dr["QunNum"].ToString());
                    usermoney_new.RoomCardNum= Int32.Parse(dr["RoomCardNum"].ToString()) ;
                    usermoney_new.Riqi= Int32.Parse(dr["Riqi"].ToString());
                    list.Add(usermoney_new);
                }
            }
            return list;
        }
    }
}
