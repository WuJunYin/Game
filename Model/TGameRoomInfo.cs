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
    
    public partial class TGameRoomInfo
    {
        public int id { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string ServerIP { get; set; }
        public int ServerInfoID { get; set; }
        public int GameTypeID { get; set; }
        public int GameKindID { get; set; }
        public int GameNameID { get; set; }
        public int SocketPort { get; set; }
        public int OnlineCount { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public short EnableRoom { get; set; }
        public short StopLogon { get; set; }
        public int IDSort { get; set; }
        public int Version { get; set; }
        public string ServiceName { get; set; }
        public int VirtualUser { get; set; }
        public int VirtualGameTime { get; set; }
        public Nullable<int> BattleRoomID { get; set; }
        public string BattleMatchTable { get; set; }
        public string RoomPassword { get; set; }
        public Nullable<int> tenancyID { get; set; }
        public int SendTimeLength { get; set; }
        public long SendCount { get; set; }
        public int AgencyID { get; set; }
    }
}
