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
    
    public partial class Web_SpreadUserRecharge
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public Nullable<long> PartnerBeforeIngot { get; set; }
        public Nullable<long> PartnerAfterIngot { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public Nullable<long> UserBeforeIngot { get; set; }
        public Nullable<long> UserAfterIngot { get; set; }
        public long RechargeAmount { get; set; }
        public long RebateAmount { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int Status { get; set; }
    }
}
