using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.User
{
    public class UserChangeMoney
    {

        /// <summary>
        /// 总列数
        /// </summary>
        public int rows { get; set; }
        /// <summary>
        /// 用户金钱改变量集合
        /// </summary>
        public List<UserMoney> ListUserMoney { get; set; }
       
        public class UserMoney
        {
            public int UserID { get; set; }
            public string UserName { get; set; }
            public decimal StartMoney { get; set; }
            public decimal ChangeMoney { get; set; }
            public int ChangeType { get; set; }
            public DateTime DateTime { get; set; }
            public string Remark { get; set; }
            public int RoomID { get; set; }
            public int QunNum { get; set; }
            public int RoomCardNum { get; set; }
            public int Riqi { get; set; }
        }
    }
}
