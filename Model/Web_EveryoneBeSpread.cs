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
    
    public partial class Web_EveryoneBeSpread
    {
        public int ID { get; set; }
        public Nullable<int> BeUserId { get; set; }
        public string BeUserName { get; set; }
        public string BeNickName { get; set; }
        public Nullable<int> UserId { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> IsReceiveUser { get; set; }
        public Nullable<int> IsReceiveBeUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
    }
}
