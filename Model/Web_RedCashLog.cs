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
    
    public partial class Web_RedCashLog
    {
        public int LogId { get; set; }
        public Nullable<decimal> Money { get; set; }
        public Nullable<int> UserId { get; set; }
        public string OpenId { get; set; }
        public string WXNickName { get; set; }
        public string IP { get; set; }
        public Nullable<int> Status { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> Tag { get; set; }
    }
}