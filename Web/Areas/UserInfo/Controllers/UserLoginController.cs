using Bll.UserInfo;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Areas.UserInfo.Controllers
{
    public class UserLoginController : ApiController
    {
        /// <summary>
        /// 员工登录
        /// </summary>
        /// <param name="name">后台员工账号</param>
        /// <param name="pwd">后台员工密码</param>
        /// <returns>code=0成功返回员工姓名,code！=0失败返回错误信息</returns>
        [HttpGet]
        public HttpResponseMessage GetUser(string name,string pwd)
        {
            string newpwd = MD5JM.Get_MD5(pwd);
            Model.UserInfo.UserInfoBackGroundModel new_user = UserInfoBll.GetUserinfo(name, newpwd);
            //string result = "";

            if (new_user!=null)
            {
                //插入一条登录信息 登录成功
                UserInfoBll.UpdateUser(new_user.UserName);

                return new HttpResponseMessage()//成功
                {
                    Content = new StringContent("{\"code\":0,\"msg\":\""+ new_user.UserName + "\"}", System.Text.Encoding.UTF8, "application/json")
                };
            }
            else
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("{\"code\":1,\"msg\":\"账号密码有误请重新登录\"}", System.Text.Encoding.UTF8, "application/json")
                };
            }
        }


        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="name">注册账号</param>
        /// <param name="pwd">注册密码</param>
        /// <returns>code=0成功返回注册账号,code！=0失败返回错误信息</returns>
        [HttpGet]
        public HttpResponseMessage AddUser(string name, string pwd)
        {
            string new_pwd = MD5JM.Get_MD5(pwd);
            if (UserInfoBll.AddUser(name, new_pwd))
            {
                return new HttpResponseMessage()//成功
                {
                    Content = new StringContent("{\"code\":0,\"msg\":\"" + name + "\"}", System.Text.Encoding.UTF8, "application/json")
                };
            }
            else
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("{\"code\":1,\"msg\":\"用户名重复,请重新注册\"}", System.Text.Encoding.UTF8, "application/json")
                };

            }
        }


        /// <summary>
        /// 接口调用
        /// </summary>
        /// <returns>返回4位随机数</returns>
        //[HttpGet]
        //public HttpResponseMessage GatCaptcha()
        //{
        //    string captcha = RandomNum(4);
        //    return new HttpResponseMessage()//成功
        //    {
        //        Content = new StringContent(captcha, System.Text.Encoding.UTF8, "application/json")
        //    };
        //}

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="n">验证码位数</param>
        /// <returns>返回4位随机数</returns>
        //private string RandomNum(int n)
        //{
        //    //定义一个包含数字 大写 小写英文字母
        //    string strchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
        //    //将strchar 字符串转化为数组
        //    //String.Split 方法放回包含此实例中的子字符串（由指定Char数组的元素分割）的String数组
        //    string[] VcArray = strchar.Split(',');
        //    string VNum = "";
        //    //记录上次随机数组，避免产生几个一样的
        //    int temp = -1;
        //    //采用一个简单的算法以保证 生产随机数的不同
        //    Random rand = new Random();
        //    for (int i = 1; i < n + 1; i++)
        //    {
        //        if (temp != -1)
        //        {
        //            //unchecked 关键字用于取消整型算术运算和转换的溢出检查。
        //            //DataTime.Ticks 属性获取表示此实例的日期和时间的刻度数。
        //            rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
        //        }
        //        //Random.Next 方法返回一个小于所指定最大值的非负数随机数。
        //        int t = rand.Next(61);
        //        if (temp != -1 && temp == t)
        //        {
        //            return RandomNum(n);
        //        }
        //        temp = t;
        //        VNum += VcArray[t];
        //    }
        //    return VNum;//返回生成的随机数
        //}
    }
}
