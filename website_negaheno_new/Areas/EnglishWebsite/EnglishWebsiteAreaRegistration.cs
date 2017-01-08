using System.Web.Mvc;

namespace website_negaheno.Areas.EnglishWebsite
{
    public class EnglishWebsiteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EnglishWebsite";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EnglishWebsite_default",
                "EnglishWebsite/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}