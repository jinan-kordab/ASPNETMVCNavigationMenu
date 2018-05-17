using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETMVCNavigationMenu.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Models.OurMenu> OurMenus = Helpers.MenuHelper.GetMenus();
            ASPNETMVCNavigationMenu.Models.MenuModel menuModel = new Models.MenuModel();
            menuModel.menus = OurMenus;

            return View("Index",menuModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult AddNewMenu(FormCollection frmc)
        {
            List<string> firstLevelArray = new List<string>();

            //iterate through all keys
            int linkOrderFirstRow = 0;
            int linkOrderSecondRow = 0;

            int linkorderInlineListSecondRow = 1;
         
            //grid no margin isnerted scope identity
            string newlyInsertedGridNoMarginFirstRowID = "";

            //inline list inserted scope identity
            string newlyInsertedInlineListFirstRowID = "";
            string newlyInsertedInlineListSecondRowID = "";

            string newlyInsertedGridNoMarginSecondRowTitle = "";
            string newlyInsertedGridNoMarginLinkWithText = "";


            int inintlistfirstrowcounter = 0;

            for (int firstLevel = 0; firstLevel < frmc.Keys.Count; firstLevel++)
            {


                if (frmc.Keys[firstLevel].ToString().Contains("grid-no-margin-first-row-text"))
                {
                    //compose SQL insert first row menu item
                    string SQL = "INSERT INTO[dbo].[NavigationMenu]([LinkLevel],[Linktype],[ParentLink],[LinkOrder],[LinkText],[HasChildren],[Class]) VALUES(1,'LINK',0," + linkOrderFirstRow + ",'" + frmc[firstLevel].ToString() + "','True','4|grid no-margin'); SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
                    

                    //Insert new first level
                    using (var dbconn = new SqlConnection("data source=(localdb)\\LocalInstance;initial catalog=NavMenuDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
                    {
                        using (var dbcm = new SqlCommand(SQL, dbconn))
                        {
                            dbconn.Open();
                            newlyInsertedGridNoMarginFirstRowID = dbcm.ExecuteScalar().ToString();
                        }
                    }


                }
                 if (frmc.Keys[firstLevel].ToString().Contains("grid-no-margin-second-row-header-title"))
                {
                    //compose SQL insert second row title
                    string SQL = "INSERT INTO[dbo].[NavigationMenu]([LinkLevel],[Linktype],[ParentLink],[LinkOrder],[LinkText],[HasChildren],[Class]) VALUES(2,'TITLE'," + newlyInsertedGridNoMarginFirstRowID + "," + linkOrderFirstRow + ",'" + frmc[firstLevel].ToString() + "','True','text-shadow'); SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
                    

                    //Insert second tow title
                    using (var dbconn = new SqlConnection("data source=(localdb)\\LocalInstance;initial catalog=NavMenuDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
                    {
                        using (var dbcm = new SqlCommand(SQL, dbconn))
                        {
                            dbconn.Open();
                            newlyInsertedGridNoMarginSecondRowTitle = dbcm.ExecuteScalar().ToString();
                        }
                    }
                }
                 if (frmc.Keys[firstLevel].ToString().Contains("linkGridNoMarginTEXT") && frmc.Keys[firstLevel +1].ToString().Contains("linkGridNoMarginLINK"))
                {
                    var temp = frmc[firstLevel + 1].ToString();

                    //compose SQL insert second row title
                    string SQL = "INSERT INTO[dbo].[NavigationMenu]([LinkLevel],[Linktype],[ParentLink],[LinkOrder],[LinkText],[HasChildren],[Class]) VALUES(2,'"+ frmc[firstLevel+1].ToString() + "'," + newlyInsertedGridNoMarginFirstRowID + "," + linkOrderFirstRow + ",'" + frmc[firstLevel].ToString() + "','True','#'); SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
                   

                    //Insert second tow title
                    using (var dbconn = new SqlConnection("data source=(localdb)\\LocalInstance;initial catalog=NavMenuDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
                    {
                        using (var dbcm = new SqlCommand(SQL, dbconn))
                        {
                            dbconn.Open();
                            newlyInsertedGridNoMarginLinkWithText = dbcm.ExecuteScalar().ToString();
                        }
                    }
                }

                ////////////////////////////////////////  INLINE LIST GENERATION  /////////////////////////////////////////

               
                    if (frmc.Keys[firstLevel].ToString().Contains("inline-list-first-row-text"))
                {
                    inintlistfirstrowcounter = inintlistfirstrowcounter + 1;

                    //compose SQL insert first row menu item
                    string SQL = "INSERT INTO[dbo].[NavigationMenu]([LinkLevel],[Linktype],[ParentLink],[LinkOrder],[LinkText],[HasChildren],[Class]) VALUES(1,'LINK',0," + linkOrderFirstRow + ",'" + frmc[firstLevel].ToString() + "','True','0|inline-list'); SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
                    linkOrderFirstRow = linkOrderFirstRow + 1;

                    //Insert new first level
                    using (var dbconn = new SqlConnection("data source=(localdb)\\LocalInstance;initial catalog=NavMenuDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
                    {
                        using (var dbcm = new SqlCommand(SQL, dbconn))
                        {
                            dbconn.Open();
                            newlyInsertedInlineListFirstRowID = dbcm.ExecuteScalar().ToString();
                        }
                    }
                }


              
                if (frmc.Keys[firstLevel].ToString().Contains("linkInlineSecondRowListTEXT") && frmc.Keys[firstLevel + 1].ToString().Contains("linkInlineSecondRowListLINK"))
                {
                    if (inintlistfirstrowcounter > 1)
                    {
                        inintlistfirstrowcounter = 0;
                        linkorderInlineListSecondRow = 0;
                    }

                    //compose SQL insert first row menu item
                    string SQL = "INSERT INTO[dbo].[NavigationMenu]([LinkLevel],[Linktype],[ParentLink],[LinkOrder],[LinkText],[HasChildren],[Class]) VALUES(2,'" + frmc[firstLevel + 1].ToString() + "'," + newlyInsertedInlineListFirstRowID + "," + linkorderInlineListSecondRow + ",'" + frmc[firstLevel].ToString() + "','True','#'); SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
                    
                    linkorderInlineListSecondRow = linkorderInlineListSecondRow + 1;

                    //Insert new first level
                    using (var dbconn = new SqlConnection("data source=(localdb)\\LocalInstance;initial catalog=NavMenuDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
                    {
                        using (var dbcm = new SqlCommand(SQL, dbconn))
                        {
                            dbconn.Open();
                            newlyInsertedInlineListSecondRowID = dbcm.ExecuteScalar().ToString();
                        }
                    }
                   
                }

            }
            using (var dbconn = new SqlConnection("data source=(localdb)\\LocalInstance;initial catalog=NavMenuDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                dbconn.Open();
                using (DbDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = dbconn.CreateCommand();
                    adapter.SelectCommand.CommandText = "SELECT * FROM [NavigationMenu]";
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    int pkid = 0;
                    int tempCounter = 0;
                    for (int row = 0; row < table.Rows.Count; row++)
                    {
                        if (table.Rows[row]["Class"].ToString().Contains("inline-list"))
                        {
                            pkid = Convert.ToInt32(table.Rows[row]["LinkId"]);
                            var sids = (from t in table.AsEnumerable()
                                        where t.Field<Int64>("ParentLink") == pkid
                                        select t).ToList();
                            tempCounter = sids.Count();

                            string SQLUpdate = "UPDATE [NavMenuDB].[dbo].[NavigationMenu] SET Class = '" + tempCounter + "|inline-list' WHERE LinkId = " + pkid.ToString() + "";
                            using (var dbcm = new SqlCommand(SQLUpdate, dbconn))
                            {
                                int e = dbcm.ExecuteNonQuery();
                            }
                        }

                    
                    }
                }
                dbconn.Close();
            }

            List<Models.OurMenu> OurMenus = Helpers.MenuHelper.GetMenus();
            ASPNETMVCNavigationMenu.Models.MenuModel menuModel = new Models.MenuModel();
            menuModel.menus = OurMenus;

            return View("Index", menuModel);
        }


    }
}