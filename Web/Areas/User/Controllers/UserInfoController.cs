using Model.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Web.Areas.User.Controllers
{
    public class UserInfoController : ApiController
    {
        /// <summary>
        /// 分页查找用户信息
        /// </summary>
        /// <param name="page">当前页数</param>
        /// <param name="row">每页条数</param>
        /// <returns>返回json，userId:用户ID，userName:用户名，NickName:昵称，
        /// WalletMoney：摩尔豆，VipLevel：VIP等级，VipeTime：VIP到期时间
        /// </returns>
        [HttpGet]
        public HttpResponseMessage GetUserInfo(int page,int row) {
            int allrow = 0;
            StringBuilder where = new StringBuilder();
            List<UserInfoModel.userModel> list = Bll.User.UserInfoBll.GetProductByStr(page, row, where.ToString(), out allrow);
            UserInfoModel userInfoModel = new UserInfoModel();
            userInfoModel.rows = allrow;
            userInfoModel.userList = list;
            string json = JsonConvert.SerializeObject(userInfoModel);
            return new HttpResponseMessage()
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json"),
            };
        }
        /// <summary>
        /// 增加摩尔豆
        /// </summary>
        /// <param name="userId">用户ID(userId)</param>
        /// <param name="num">新增数量</param>
        /// <returns>返回消息（字符串类型直接显示即可）</returns>
        [HttpGet]
        public string UpdateUserWalletMoney(int userId,int num) {
            Model.moerDataEntities moerDataEntities = new Model.moerDataEntities();
            Model.TUserInfo userInfo = moerDataEntities.TUserInfo.FirstOrDefault(item => item.UserID == userId);
            if (userInfo != null)
            {
                userInfo.WalletMoney = userInfo.WalletMoney + num;
                if (moerDataEntities.SaveChanges() > 0)
                {
                    return "修改成功";
                }
                else {
                    return "修改失败";
                }
            }
            else {
                return "查无此数据";
            }            
        }

        /// <summary>
        /// 玩家游戏金币变化表
        /// </summary>
        /// <param name="page">当前页数</param>
        /// <param name="row">每页条数</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetUserMoneyChange(int page, int row)
        {
            int allrow = 0;
            StringBuilder where = new StringBuilder();//条件待定
            List<UserChangeMoney.UserMoney> list = Bll.User.UserInfoBll.GetUserMoney(page,row,where.ToString(),out allrow);
            UserChangeMoney userchangemoney = new UserChangeMoney();
            userchangemoney.rows = allrow;
            userchangemoney.ListUserMoney = list;//把数据放入集合中
            string json = JsonConvert.SerializeObject(userchangemoney);
            return new HttpResponseMessage()
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json"),
            };
        }
    }
}
