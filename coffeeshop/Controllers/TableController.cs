using System;
using System.Collections.Generic;
using coffeeshop.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeshop.Controllers
{
    public class TableController : Controller
    {
        //for admin use
        public ActionResult TablesList()
        {
            using(DbModels dbModel = new DbModels())
            {
                return View(dbModel.ShopTables.ToList());
            }

        }

        //before order choose table
        public ActionResult ChooseTable()
        {
            using(DbModels dbModel = new DbModels())
            {
                return View(dbModel.ShopTables.ToList());
            }

        }

        //after table choosed, goto Menu 
        public ActionResult Order()
        {
            return RedirectToAction("ProductsView", "Product");
        }

        //edit table 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                var table = dbModels.ShopTables.Where(x => x.TableID == id).FirstOrDefault();
                return View(table);
            }

        }

        [HttpPost]
        public ActionResult Edit(ShopTable table)
        {
            using (DbModels dbModels = new DbModels())
            {
                var tab = dbModels.ShopTables.Where(x => x.TableID == table.TableID).FirstOrDefault();             
            }
            return RedirectToAction("TablesList");
        }

        //delete item from tablesList
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                var table = dbModels.ShopTables.Where(x => x.TableID == id).FirstOrDefault();
                return View(table);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ShopTable table)
        {
            using (DbModels dbModels = new DbModels())
            {
                var tab = dbModels.ShopTables.Where(x => x.TableID == table.TableID).FirstOrDefault();
                if (tab != null)
                {
                    dbModels.ShopTables.Remove(tab);
                    dbModels.SaveChanges();
                }
            }
            return RedirectToAction("TablesList");
        }
    }
}