using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Web.Areas.SendSMS.Controllers
{    
    public class SendValidCodeController : ApiController
    {
        // GET api/<controller>
        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="phone">电话号码</param>
        /// <returns>返回json，其中code=0表示发送成功，否则失败，msg为失败内容</returns>
        [HttpGet]
        public HttpResponseMessage sendCode(string phone)
        {
            string smscode = new System.Random(unchecked((int)DateTime.Now.Ticks)).Next(100000, 999999).ToString();
            string tpl_id = "2776178";
            string tpl_value = "%23code%23=" + smscode;
            string result = "";
            Bll.SendSMSBll.sendSMS(phone, tpl_id, tpl_value, out result);
            Models.CodeResult codeResult = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.CodeResult>(result);

            if (result.StartsWith("{\"code\":0,")) // 发送成功
            {
                Model.tab_SendSMS tab_SendSMS = new Model.tab_SendSMS();
                tab_SendSMS.code = smscode;
                tab_SendSMS.isUse = false;
                tab_SendSMS.phone = phone;
                tab_SendSMS.workDate = DateTime.Now;
                Model.moerDataEntities moerDataEntities = new Model.moerDataEntities();
                moerDataEntities.tab_SendSMS.Add(tab_SendSMS);
                if (moerDataEntities.SaveChanges() > 0)
                {
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json"),
                    };
                }
                else {
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("{\"code\":0,\"msg\":\"error\"}", System.Text.Encoding.UTF8, "application/json"),
                    };
                }
            }
            else {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json"),
                };
            }          
        }
    }
}
