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
    
    public partial class Web_TuiGuangLog
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> TG_UserID { get; set; }
        public Nullable<System.DateTime> RegTime { get; set; }
        public Nullable<int> GameTimeCount { get; set; }
        public Nullable<int> GetMoney { get; set; }
        public Nullable<System.DateTime> CalTime { get; set; }
        public Nullable<bool> IsRegAward { get; set; }
        public Nullable<bool> IsClearing { get; set; }
        public Nullable<int> PayStatus { get; set; }
        public Nullable<System.DateTime> PayTime { get; set; }
    }
}
