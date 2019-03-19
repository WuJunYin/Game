using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Web.Areas.Upload.Controllers
{
    public class UploadController : ApiController
    {
        //// <summary>
        /// 上传文件 使用上传后的默认文件名称
        /// 默认名称是BodyPart_XXXXXX，BodyPart_加Guid码
        /// </summary>
        /// <returns></returns>
        [HttpPost]//Route("Upload")
        public string Upload()
        {
            
            string result = "";
            //获取客户端上传文件
            HttpFileCollection filelist = HttpContext.Current.Request.Files;
            if (filelist != null && filelist.Count > 0)
            {
                for (int i = 0; i < filelist.Count; i++)
                {
                    HttpPostedFile file = filelist[i];
                    string filename = file.FileName;//上传文件夹名称
                    string FilePath = HttpContext.Current.Server.MapPath(@"/Upload/APK");//目标文件夹

                    DirectoryInfo di = new DirectoryInfo(FilePath);
                    if (!di.Exists) { di.Create(); }
                    try
                    {
                        file.SaveAs(FilePath+"\\"+filename);
                        return "上传成功";
                    }
                    catch(Exception ex)
                    {
                        result = "上传文件写入失败：" + ex.Message;
                    }
                }
            }
            else
            {
                result = "上传的文件信息不存在！";
            }

            return result;
        }
    }
}
