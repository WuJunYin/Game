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
    
    public partial class TProc_Error_Log
    {
        public long ProID { get; set; }
        public string ProName { get; set; }
        public string ProParam { get; set; }
        public Nullable<int> ProNumber { get; set; }
        public Nullable<int> ProLine { get; set; }
        public string ProMessage { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
    }
}