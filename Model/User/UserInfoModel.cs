using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.User
{
    public class UserInfoModel
    {
        /// <summary>
        /// 总的数据量
        /// </summary>
        public int rows { get; set; }
        public List<userModel> userList { get; set; }
        public class userModel
        {
            /// <summary>
            /// 用户ID
            /// </summary>
            public int UserID { get; set; }
            /// <summary>
            /// 用户名
            /// </summary>
            public string userName { get; set; }
            /// <summary>
            /// 昵称
            /// </summary>
            public string NickName { get; set;}
            /// <summary>
            /// 摩尔豆
            /// </summary>
            public int WalletMoney { get; set; }
            /// <summary>
            /// VIP等级
            /// </summary>
            public int VipLevel { get; set; }
            /// <summary>
            /// VIP到期时间
            /// </summary>
            public DateTime VipeTime { get; set; }
        }
    }
}
