using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Client
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
