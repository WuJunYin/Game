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
    
    public partial class Web_AgencyPercentChange
    {
        public int ID { get; set; }
        public int OperaID { get; set; }
        public int AgencyID { get; set; }
        public int BPercent { get; set; }
        public int APercent { get; set; }
        public int Change { get; set; }
        public System.DateTime AddTime { get; set; }
        public int OperaType { get; set; }
    }
}