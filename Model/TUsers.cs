//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TUsers
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string TwoPassword { get; set; }
        public string NickName { get; set; }
        public int LogoID { get; set; }
        public string LogoFileMD5 { get; set; }
        public string Token { get; set; }
        public int OnlineFlag { get; set; }
        public int Disabled { get; set; }
        public short Sex { get; set; }
        public short IsRobot { get; set; }
        public int AgencyID { get; set; }
        public string Salt { get; set; }
        public Nullable<int> Limit { get; set; }
        public string Source { get; set; }
        public Nullable<long> GameTimes { get; set; }
        public Nullable<byte> is_open { get; set; }
        public string unionid { get; set; }
        public string access_token { get; set; }
        public string headimgurl { get; set; }
        public string openid { get; set; }
        public string scope { get; set; }
        public Nullable<int> InQunCount { get; set; }
        public Nullable<int> LastLoadTime { get; set; }
        public string ZJ_Number { get; set; }
    }
}