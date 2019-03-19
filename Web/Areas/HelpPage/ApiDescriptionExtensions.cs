using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http.Description;

namespace Web.Areas.HelpPage
{
    public static class ApiDescriptionExtensions
    {
        /// <summary>
        /// Generates an URI-friendly ID for the <see cref="ApiDescription"/>. E.g. "Get-Values-id_name" instead of "GetValues/{id}?name={name}"
        /// </summary>
        /// <param name="description">The <see cref="ApiDescription"/>.</param>
        /// <returns>The ID as a string.</returns>
        public static string GetFriendlyId(this ApiDescription description)
        {
            string controllerFullName = description.ActionDescriptor.ControllerDescriptor.ControllerType.FullName;
            //匹配areaName
            string areaName = Regex.Match(controllerFullName, @"Area.([^,]+)\.C").Groups[1].ToString().Replace(".", "");
            if (string.IsNullOrEmpty(areaName))
            {
                //若不是areas下的controller,将路由格式中的{area}去掉
                description.RelativePath = description.RelativePath.Replace("{area}/", "");
            }
            else
            {
                //若是areas下的controller,将路由格式中的{area}替换为真实areaname
                description.RelativePath = description.RelativePath.Replace("{area}", areaName);
            }
            string path = description.RelativePath;
            string[] urlParts = path.Split('?');
            string localPath = urlParts[0];
            string queryKeyString = null;
            if (urlParts.Length > 1)
            {
                string query = urlParts[1];
                string[] queryKeys = HttpUtility.ParseQueryString(query).AllKeys;
                queryKeyString = String.Join("_", queryKeys);
            }

            StringBuilder friendlyPath = new StringBuilder();
            friendlyPath.AppendFormat("{0}-{1}",
                description.HttpMethod.Method,
                localPath.Replace("/", "-").Replace("{", String.Empty).Replace("}", String.Empty));
            if (queryKeyString != null)
            {
                friendlyPath.AppendFormat("_{0}", queryKeyString.Replace('.', '-'));
            }
            return friendlyPath.ToString();
        }
    }
}