using System.Web.Mvc;
using System.Web.Routing;

namespace WhatToEat
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Account", "Account/{action}/{id}", new { controller = "Account", action = "Index", id = UrlParameter.Optional }, new[] { "WhatToEat.Controllers" });
            routes.MapRoute("Eatery", "Eatery/{action}/{name}", new { Controller = "Eatery", action = "Index", name = UrlParameter.Optional }, new[] { "WhatToEat.Controllers" });
            routes.MapRoute("SidebarPartial", "Pages/SidebarPartial", new { Controller = "Pages", action = "SidebarPartial" }, new[] { "WhatToEat.Controllers" });
            routes.MapRoute("PagesMenuPartial", "Pages/PagesMenuPartial", new { Controller = "Pages", action = "PagesMenuPartial" }, new[] { "WhatToEat.Controllers" });
            routes.MapRoute("Pages", "{page}", new { Controller = "Pages", action = "Index" }, new[] { "WhatToEat.Controllers" });
            routes.MapRoute("Default", "", new { Controller = "Pages", action = "Index" }, new[] { "WhatToEat.Controllers" });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
