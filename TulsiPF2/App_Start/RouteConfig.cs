﻿using System.Web.Mvc;
using System.Web.Routing;

namespace TulsiPF2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                 name: "MemberActivities",
                 url: "Home/MemActivities/{id}",
                 defaults: new { controller = "Home", action = "MemActvities" }
            );

            routes.MapRoute(
                 name: "MemberListing",
                 url: "Home/MemListing/{id}",
                 defaults: new { controller = "Home", action = "MemListing" }
               );

            routes.MapRoute(
                 name: "DonationTabs",
                 url: "DonationTabs/index",
                 defaults: new { controller = "DonationTabs", action = "Index" }
            );

            routes.MapRoute(
                 name: "MemberDetails",
                 url: "Members/index/{id}",
                 defaults: new { controller = "Members", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "ImageTabs",
                 url: "ImageTabs/AddImage/{id}",
                 defaults: new { controller = "ImageTabs", action = "AddImage", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "User",
                url: "User/Index/{id}",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
                );

   

            routes.MapRoute(
               name: "MemberProfile",
               url: "MemberList/MemberProfile/{id}",
               defaults: new { controller = "MemberList", action = "MemberProfile", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Registration",
               url: "UsersRegister/Registration/{id}",
               defaults: new { controller = "UsersRegister", action = "Registration", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                  name: "Home",
                  url: "",
                  defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
