using System.Web.Mvc;

namespace Web.Areas.test3
{
    public class test3AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "test3";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "test3_default",
                "test3/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}