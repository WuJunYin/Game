using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class HttpHelper
    {
        /// <summary>
        /// 向服务器 POST 数据
        /// </summary>
        /// <param name="result">接收返回内容</param>
        /// <param name="postUrl">服务器地址</param>
        /// <param name="paramData">数据(eg: "键=值&name=Kity"，注意值部份需用 string System.Web.HttpUtility.UrlPathEncode(string) 进行编码)</param>
        /// <param name="dataEncode">参数编码(eg: System.Text.Encoding.UTF8)</param>
        /// <returns>请求成功则用服务器返回内容填充result, 否则用异常消息填充</returns>
        public static bool PostWebRequest(out string result, string postUrl, string paramData, System.Text.Encoding dataEncode)
        {
            try
            {
                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                System.Net.HttpWebRequest webReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(new Uri(postUrl));
                //webReq.ProtocolVersion = new Version("1.0");
                //webReq.UserAgent = "";
                //webReq.CookieContainer = new System.Net.CookieContainer();
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = byteArray.Length;

                System.IO.Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)webReq.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), dataEncode);
                result = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return false;
            }
            return true;
        }
    }
}
