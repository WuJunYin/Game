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
    
    public partial class Web_SpreadPartnerRecharge
    {
        public int Id { get; set; }
        public int BuyerPartnerId { get; set; }
        public string BuyerName { get; set; }
        public Nullable<long> BuyerBeforeIngot { get; set; }
        public Nullable<long> BuyerAfterIngot { get; set; }
        public int SellerPartnerId { get; set; }
        public string SellerName { get; set; }
        public Nullable<long> SellerBeforeIngot { get; set; }
        public Nullable<long> SellerAfterIngot { get; set; }
        public int BuyerParentId { get; set; }
        public long RechargeAmount { get; set; }
        public long RebateAmount { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int RebateStatus { get; set; }
        public int HasRebate { get; set; }
    }
}
