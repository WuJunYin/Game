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
    
    public partial class Web_Users
    {
        public int UserID { get; set; }
        public string RegisterIP { get; set; }
        public string RegisterMac { get; set; }
        public System.DateTime RegisterTM { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int WebLoginTime { get; set; }
        public string Pwd_anw { get; set; }
        public string Pwd_ques { get; set; }
        public Nullable<short> ZJ_type { get; set; }
        public string ZJ_Number { get; set; }
        public string qqnum { get; set; }
        public string RealName { get; set; }
        public string SignDescr { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string Schooling { get; set; }
        public string HomePage { get; set; }
        public string TelNo { get; set; }
        public string MSNID { get; set; }
        public int Lotteries { get; set; }
        public Nullable<short> PhoneValid { get; set; }
        public Nullable<short> EmailValid { get; set; }
        public Nullable<short> ZJValid { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Remark { get; set; }
        public Nullable<long> IsAttention { get; set; }
        public string WeiXinUnionId { get; set; }
        public string WeiXinOpenId { get; set; }
        public string WeiXinSceneId { get; set; }
        public string WeiXinQrCode { get; set; }
        public Nullable<System.DateTime> WeiXinTimeout { get; set; }
        public string WeiXinNickName { get; set; }
        public string WeiXinPhoto { get; set; }
        public Nullable<long> MinMoney { get; set; }
        public Nullable<long> MaxMoney { get; set; }
        public Nullable<System.DateTime> MonitorTime { get; set; }
        public string MonitorMsg { get; set; }
        public string MonitorData { get; set; }
    }
}
