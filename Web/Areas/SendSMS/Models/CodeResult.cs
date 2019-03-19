using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.SendSMS.Models
{
    public class CodeResult
    {
        public int code { get; set; }  //0代表发送成功，其他code代表出错，详细见"返回值说明"页面
        public string msg { get; set; }  //例如""发送成功""，或者相应错误信息
        public int count { get; set; }  //发送成功短信的计费条数(计费条数：70个字一条，超出70个字时按每67字一条计费)
        public double fee { get; set; }  //扣费金额，单位：元，类型：双精度浮点型/double
        public string unit { get; set; }  //计费单位；例如：“RMB”
        public string mobile { get; set; } //发送手机号
        public long sid { get; set; } //短信id，64位整型， 对应Java和C#的long，不可用int解析
    }
}