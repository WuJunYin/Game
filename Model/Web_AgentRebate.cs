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
    
    public partial class Web_AgentRebate
    {
        public int RebateId { get; set; }
        public string AgentName { get; set; }
        public Nullable<int> TotalUseScore { get; set; }
        public Nullable<int> TotalGiveMoney { get; set; }
        public Nullable<int> LimitPoint { get; set; }
        public Nullable<int> OneUseScore { get; set; }
        public Nullable<int> OneGiveMoney { get; set; }
        public Nullable<int> OneGivePoint { get; set; }
        public Nullable<int> TwoUseScore { get; set; }
        public Nullable<int> TwoGiveMoney { get; set; }
        public Nullable<int> TwoGivePoint { get; set; }
        public Nullable<int> ThreeUseScore { get; set; }
        public Nullable<int> ThreeGiveMoney { get; set; }
        public Nullable<int> ThreeGivePoint { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> ApplyTime { get; set; }
        public Nullable<System.DateTime> GiveTime { get; set; }
    }
}