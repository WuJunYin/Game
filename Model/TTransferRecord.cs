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
    
    public partial class TTransferRecord
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int DestUserID { get; set; }
        public long TransferMoney { get; set; }
        public long ActualTransfer { get; set; }
        public System.DateTime TransTime { get; set; }
        public long TranBOnceValue { get; set; }
    }
}