using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETMVCNavigationMenu.Models
{
    public class OurMenu
    {
        public long LinkId;
        public int LinkLevel;
        public string Linktype;
        public long ParentLink;
        public int LinkOrder;
        public string LinkText;
        public bool HasChildren;
        public string Class;
    }
}