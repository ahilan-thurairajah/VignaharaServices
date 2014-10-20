using System;
using DotNetNuke.Web.Api;

namespace VignaharaServices
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("VignaharaServices", "default", "{controller}/{action}", new[] { "VignaharaServices" });
        }
    }
}
