using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class SendSMSBll
    {
        /// <summary>
        /// 发送短信, 使用示例：
        /// string result = EMPTY; // 用来接收返回内容，失败时保存原因描述
        /// eg: if (sendSMS("18888888888", "2151202", "%23code%23=" +smscode, out result)) /*发送成功后的处理*/;
        /// </summary>
        /// <param name="phoneNumber">符合规范的接收号码</param>
        /// <param name="tpl_id">短信模板id</param>
        /// <param name="tpl_value">短信模板值,eg: %23code%23=92138, %23 表示 # 号</param>
        /// <param name="result">发送成功则返回 true,否则返回 false</param>
        /// <returns></returns>
        public static string sendSMS(string phoneNumber, string tpl_id, string tpl_value, out string result)
        {
            string providerUrl = "https://sms.yunpian.com/v2/sms/tpl_single_send.json"; // 指定模板发送方式
            string apikey = "87f637e44e5d70d2f9a0a259db2e66cf"; //请用自己的apikey代替
            string dat = "apikey=" + apikey + "&mobile=" + phoneNumber + "&tpl_id=" + tpl_id + "&tpl_value=" + tpl_value;

            if (!HttpHelper.PostWebRequest(out result, providerUrl, dat, System.Text.Encoding.UTF8)) return ""; // 请求失败， result 值是网络错误描述

            // 错误时返回值示例：{"code":2,"msg":"请求参数格式错误","detail":"验证码类模板#code#值长度必须1-16个字，且只能是字母和数字"}
            // 成功时返回值示例：{"code":0,"msg":"发送成功","count":1,"fee":0.042,"unit":"RMB","mobile":"18974485282","sid":21830992082}

            return result;
        }

        //public HttpResponseMessage getVoid() {
        //    string smscode = new System.Random(unchecked((int)DateTime.Now.Ticks)).Next(100000, 999999).ToString();
        //    string tpl_id = "2151204";
        //    string tpl_value = "%23code%23=" + smscode;
        //    string result = "";
        //    Bll.SendSMS.sendSMS("15323718917", tpl_id, tpl_value, out result);
        //    Models.CodeResult codeResult = JsonConvert.DeserializeObject<Models.CodeResult>(result);
        //    if (result.StartsWith("{\"code\":0,")) // 发送成功
        //    {

        //    }
        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent(result, Encoding.UTF8, "application/json"),
        //    };
        //}
    }
}
