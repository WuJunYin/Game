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
    
    public partial class Web_RMBCost
    {
        public int PayID { get; set; }
        public Nullable<int> Users_ids { get; set; }
        public string TrueName { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public Nullable<long> PayMoney { get; set; }
        public Nullable<byte> PayType { get; set; }
        public string TypeInfo { get; set; }
        public string OrderID { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<int> ExchangeRate { get; set; }
        public Nullable<int> InMoney { get; set; }
        public Nullable<bool> InSuccess { get; set; }
        public Nullable<bool> PaySuccess { get; set; }
        public Nullable<System.DateTime> BackTime { get; set; }
        public string EncryptStr { get; set; }
        public string Info { get; set; }
        public Nullable<long> MoneyFront { get; set; }
        public Nullable<long> MoneyAfter { get; set; }
        public Nullable<byte> UpdateFlag { get; set; }
        public int PurchaseType { get; set; }
    }
}