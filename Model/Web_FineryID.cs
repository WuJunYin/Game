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
    
    public partial class Web_FineryID
    {
        public int FineryID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string PassWord { get; set; }
        public int Price { get; set; }
        public string Explain { get; set; }
        public bool IsBuy { get; set; }
        public bool IsUse { get; set; }
        public bool IsSale { get; set; }
        public bool IsTop { get; set; }
        public bool IsCopy { get; set; }
        public System.DateTime DateTime { get; set; }
        public Nullable<System.DateTime> DateTimeBuy { get; set; }
        public Nullable<System.DateTime> DateTimeUse { get; set; }
        public Nullable<System.DateTime> DateTimeCopy { get; set; }
    }
}