using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETMVCNavigationMenu.Helpers
{
    public class MenuHelper
    {
        public static List<Models.OurMenu> GetMenus()
        {
            List<Models.OurMenu> OurMenus;
            using (var ourMenus = new ASPNETMVCNavigationMenu.EntityFramework.NavMenuDBEntities())
            {
                var menusList = (from c in ourMenus.NavigationMenus
                            select new Models.OurMenu()
                            {

                                LinkId = c.LinkId,
                                LinkLevel = c.LinkLevel,
                                Linktype = c.Linktype,
                                ParentLink = c.ParentLink,
                                LinkOrder = c.LinkOrder,
                                LinkText = c.LinkText,
                                HasChildren = c.HasChildren,
                                Class = c.Class
                            }).ToList();
                OurMenus = menusList;
            }
            return OurMenus;
        }
    }
}