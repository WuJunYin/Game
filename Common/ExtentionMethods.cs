using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace Common
{
    public static class ExtentionMethods
    {
        #region+++++++++++++++++++++字符串操作与判断++++++++++++++++++++++++++++++

        /// <summary>
        /// 是否为Null或者空字符串(包括string.Empty和"",多个空格也算做"")
        /// </summary>
        /// <param name="str">用于判断的目标字符串</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this String str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 是否为整型数据
        /// </summary>
        /// <param name="str">用于判断的目标字符串</param>
        /// <returns></returns>
        public static bool IsInt(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                int temp;

                return int.TryParse(str, out temp);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否为布尔值
        /// </summary>
        /// <param name="str">用于判断的目标字符串</param>
        /// <returns></returns>
        public static bool IsBool(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                bool temp;

                return bool.TryParse(str, out temp);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否为时间类型的数据
        /// </summary>
        /// <param name="str">用于判断的目标字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                DateTime temp;

                return DateTime.TryParse(str, out temp);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否为单精度浮点型数据
        /// </summary>
        /// <param name="str">用于判断的目标字符串</param>
        /// <returns></returns>
        public static bool IsFloat(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                float temp;

                return float.TryParse(str, out temp);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否为双精度浮点型数据
        /// </summary>
        /// <param name="str">用于判断的目标字符串</param>
        /// <returns></returns>
        public static bool IsDouble(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                double temp;

                return double.TryParse(str, out temp);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 转换成整型数据,转换失败将返回0
        /// </summary>
        /// <param name="str">将要被转换的字符串</param>
        /// <returns></returns>
        public static int ToInt(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                int temp;

                if (int.TryParse(str, out temp))
                {
                    return temp;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换成布尔型数据,转换失败将返回false
        /// </summary>
        /// <param name="str">将要被转换的字符串</param>
        /// <returns></returns>
        public static bool ToBool(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                bool temp;

                if (bool.TryParse(str, out temp))
                {
                    return temp;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 转换成时间类型数据,转换失败将返回最小时间(DateTime.MinValue)
        /// </summary>
        /// <param name="str">将要被转换的字符串</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                DateTime temp;

                if (DateTime.TryParse(str, out temp))
                {
                    return temp;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// 转换成单精度浮点型数据,转换失败将返回0.0f
        /// </summary>
        /// <param name="str">将要被转换的字符串</param>
        /// <returns></returns>
        public static float ToFloat(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                float temp;

                if (float.TryParse(str, out temp))
                {
                    return temp;
                }
                else
                {
                    return 0.0f;
                }
            }
            else
            {
                return 0.0f;
            }
        }
        /// <summary>
        /// 转换成decimal,转换失败将返回0
        /// </summary>
        /// <param name="str">将要被转换的字符串</param>
        /// <returns></returns>
        public static decimal ToDecimal(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                decimal temp;

                if (decimal.TryParse(str, out temp))
                {
                    return temp;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 将字符串进行Base64编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncodeBase64(this String str)
        {
            if (!str.IsNullOrEmpty())
            {
                try
                {
                    return Convert.ToBase64String(Encoding.Default.GetBytes(str));
                }
                catch
                {
                    return string.Empty;
                }
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 将字符串进行Base64解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecodeBase64(this String str)
        {
            if (!str.IsNullOrEmpty())
            {
                try
                {
                    return Encoding.Default.GetString(Convert.FromBase64String(str));
                }
                catch
                {
                    return string.Empty;
                }
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 将字符串进行Url编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncode(this String str)
        {
            if (!str.IsNullOrEmpty())
            {
                try
                {
                    return System.Web.HttpServerUtility.UrlTokenEncode(Encoding.Default.GetBytes(str));
                }
                catch
                {
                    return string.Empty;
                }
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 将字符串进行Url解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlDecode(this String str)
        {
            if (!str.IsNullOrEmpty())
            {
                try
                {
                    return Encoding.Default.GetString(System.Web.HttpServerUtility.UrlTokenDecode(str));
                }
                catch
                {
                    return string.Empty;
                }
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 转换成双精度浮点型数据,转换失败将返回0.0d
        /// </summary>
        /// <param name="str">将要被转换的字符串</param>
        /// <returns></returns>
        public static double ToDouble(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                double temp;

                if (double.TryParse(str, out temp))
                {
                    return temp;
                }
                else
                {
                    return 0.0d;
                }
            }
            else
            {
                return 0.0d;
            }
        }

        /// <summary>
        /// 是否是手机号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsMobile(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                Regex mobileRegx = new Regex("^(\\+[0-9]{1,4}\\-){0,1}1(3|4|6|2|7|9|5|8)[0-9]{9}$");

                return mobileRegx.IsMatch(str);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否是固定电话
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPhone(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                Regex mobileRegx = new Regex("^(\\+[0-9]{1,4}\\-){0,1}[0-9]{1,5}\\-[0-9]{1,9}$");

                return mobileRegx.IsMatch(str);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否是电子邮箱地址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmail(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                Regex mobileRegx = new Regex("^(\\w)+(\\.\\w+)*@(\\w)+((\\.\\w{2,3}){1,3})$");

                return mobileRegx.IsMatch(str);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否是邮政编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPostal(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                Regex mobileRegx = new Regex("^[0-9]{6}$");

                return mobileRegx.IsMatch(str);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否是正整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumber(this String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                Regex mobileRegx = new Regex("^[0-9]{1,}$");

                return mobileRegx.IsMatch(str);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 向字符串中指定文本后面添加文本
        /// </summary>
        /// <param name="str"></param>
        /// <param name="beginStr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Insert(this String str, string beginStr, string value)
        {
            if (!str.IsNullOrEmpty())
            {
                int start = str.IndexOf(beginStr);

                if (start < 0)
                {
                    return str;
                }
                else
                {
                    return str.Insert(start + beginStr.Length, value);
                }
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 是否为英文域名(域名前缀判断,并非整个域名)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEnDomainName(this String str)
        {
            if (str.IsNullOrEmpty())
            {
                return false;
            }

            Regex reg = new Regex("^[0-9a-zA-Z\\-]{2,42}$", RegexOptions.IgnoreCase);

            return reg.IsMatch(str) && str.IndexOf('-') != 0 && str.LastIndexOf('-') != str.Length - 1;
        }

        #endregion

        #region+++++++++++++++++++++其他++++++++++++++++++++++++++++
        /// <summary>
        /// 当前文本框的值与默认提示值是否相同
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static bool IsDefaultText(this TextBox textBox)
        {
            bool flag = false;

            if (textBox != null)
            {
                if (!string.IsNullOrEmpty(textBox.Attributes["DefaultText"]))
                {
                    if (textBox.Text.Trim() == textBox.Attributes["DefaultText"].Trim())
                    {
                        flag = true;
                    }
                }
            }

            return flag;
        }

        /// <summary>
        /// 当前文本框是否输入了值
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static bool IsNoInput(this TextBox textBox)
        {
            bool flag = false;

            if (textBox != null)
            {
                if (textBox.IsDefaultText() || textBox.Text.IsNullOrEmpty())
                {
                    flag = true;
                }
            }

            return flag;
        }

        /// <summary>
        /// 获取当前月份中最小的一天的日期时间值
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetMinDay(this System.DateTime date)
        {
            return date.AddDays(-(date.Day - 1));
        }

        /// <summary>
        /// 获取当前月份中最大的一天的日期时间值
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetMaxDay(this System.DateTime date)
        {
            int days = DateTime.DaysInMonth(date.Year, date.Month);

            if (days == date.Day)
            {
                return date;
            }
            else
            {
                return date.AddDays((days - date.Day));
            }
        }

        /// <summary>
        /// 获取当前年份中最小的一个月的日期时间值
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetMinMonth(this System.DateTime date)
        {
            return date.AddMonths(-(date.Month - 1));
        }

        /// <summary>
        /// 获取当前年份中最大的一个月的日期时间值
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetMaxMonth(this System.DateTime date)
        {
            if (date.Month == 12)
            {
                return date;
            }
            else
            {
                return date.AddMonths((12 - date.Month));
            }
        }

        /// <summary>
        /// 将时间转换成文本描述形态
        /// </summary>
        /// <returns></returns>
        public static string ToLocalCnDate(this System.DateTime date)
        {
            string str = "";

            if (date.Year == DateTime.Now.Year && date.Month == DateTime.Now.Month)
            {
                if (date.Day == DateTime.Now.Day)
                {
                    str = "今天 " + date.ToString("HH:mm");
                }
                else if ((date - DateTime.Now).Days == -1)
                {
                    str = "昨天 " + date.ToString("HH:mm");
                }
                else if ((date - DateTime.Now).Days == -2)
                {
                    str = "前天 " + date.ToString("HH:mm");
                }
                else
                {
                    str = date.ToString("yyyy.MM.dd HH:mm");
                }
            }
            else
            {
                str = date.ToString("yyyy.MM.dd HH:mm");
            }

            return str;
        }

        /// <summary>
        /// 将字符串截取到指定位数
        /// </summary>
        /// <param name="str">当前操作的字符串变量</param>
        /// <param name="cutLength">截取长度</param>
        /// <param name="cutEndStr">截取后附加的字符串</param>
        /// <returns></returns>
        public static string CutString(this string str, int cutLength, string cutEndStr)
        {
            if (str.IsNullOrEmpty() || str.Length <= cutLength || cutLength <= 0)
            {
                return str;
            }
            else
            {
                return str.Substring(0, cutLength) + (cutEndStr.IsNullOrEmpty() ? "" : cutEndStr);
            }
        }

        /// <summary>
        /// 将指定数量的特定字符串拼凑成一个字符串
        /// </summary>
        /// <param name="num"></param>
        /// <param name="replaceStr"></param>
        /// <returns></returns>
        public static string GetReplaceString(this int num, string replaceStr)
        {
            string resultStr = "";

            if (!replaceStr.IsNullOrEmpty())
            {
                if (num > 0)
                {
                    for (int i = 0; i < num; i++)
                    {
                        resultStr += replaceStr;
                    }
                }
            }

            return resultStr;
        }

        /// <summary>
        /// 将Email的@符号前的帐号部分替换成*号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSecurityEmail(this string str)
        {
            if (str.IsEmail())
            {
                if (str.IndexOf("@") > 1)
                {
                    string prifx = str.Substring(0, str.IndexOf("@"));

                    int secCount = (int)Math.Floor(prifx.Length / 2.0);

                    if (secCount > 0)
                    {
                        prifx = prifx.Substring(0, secCount) + secCount.GetReplaceString("*");

                        str = prifx + str.Substring(str.IndexOf("@"));
                    }
                }
            }

            return str;
        }

        /// <summary>
        /// 将手机号码的部分替换成*号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSecurityMobile(this string str)
        {
            if (str.IsMobile() && str.Length >= 7)
            {
                int secCount = 4;

                if (secCount > 0)
                {
                    str = str.Substring(0, 3) + secCount.GetReplaceString("*") + str.Substring(6);
                }
            }

            return str;
        }

        /// <summary>       
        /// 获取远程访问用户的Ip地址       
        /// </summary>
        /// <param name="request">当前请求对象</param>
        /// <returns>Ip地址</returns>
        public static string GetCustomerIP(this System.Web.HttpRequest request)
        {
            string ip = "";

            //Request.ServerVariables[""]--获取服务变量集合 
            if (request.ServerVariables["REMOTE_ADDR"] != null) //判断发出请求的远程主机的ip地址是否为空
            {
                //获取发出请求的远程主机的Ip地址
                ip = request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            else if (request.ServerVariables["HTTP_VIA"] != null)//判断登记用户是否使用设置代理
            {
                if (request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    //获取代理的服务器Ip地址
                    ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    //获取客户端IP
                    ip = request.UserHostAddress;
                }
            }
            else
            {
                //获取客户端IP
                ip = request.UserHostAddress;
            }

            return ip;
        }

        /// <summary>
        /// 获取当前站点的域名 包含http://或https://
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetCurrWebSite(this System.Web.HttpRequest request)
        {
            string currDomain = request.Url.Scheme + "://" + request.Url.Host + (request.Url.Port == 80 || request.Url.Port == 443 ? "" : (":" + request.Url.Port.ToString()));
            return currDomain;
        }

        /// <summary>
        /// 将DataSet 转换成带架构的xml
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string GetXmlAndSchema(this DataSet ds)
        {
            try
            {
                StringBuilder xmlDataStr = new StringBuilder();
                System.Xml.XmlWriter witer = System.Xml.XmlWriter.Create(xmlDataStr);
                ds.WriteXml(witer, XmlWriteMode.WriteSchema);
                witer.Flush();
                witer.Close();
                return xmlDataStr.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
