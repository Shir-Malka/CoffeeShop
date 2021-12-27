using System.Linq;
using System.Web.Mvc;
using coffeeshop.Models;

namespace coffeeshop.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult ProductsView()
        {
            using(DbModels dbModel = new DbModels())
            {
                return View(dbModel.Products.ToList());
            }
        }

        public ActionResult ProductsList()
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Products.ToList());
            }
        }


        //add new item
        //public ActionResult AddNewItem()
        //{
        //    return View();
        //}

        //edit item 
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                var product = dbModels.Products.Where(x => x.ProductID == id).FirstOrDefault();
                return View(product);
            }

        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            using (DbModels dbModels = new DbModels())
            {
                var prod = dbModels.Products.Where(x => x.ProductID == product.ProductID).FirstOrDefault();
                //if (prod != null)
                //{
                //    dbModels.Products.Remove(prod);
                //    dbModels.Products.Add(product);
                //    dbModels.SaveChanges();
                //}                
            }
            return RedirectToAction("ProductsList");
        }

        //delete item from menu
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                var product = dbModels.Products.Where(x => x.ProductID == id).FirstOrDefault();
                return View(product);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            using (DbModels dbModels = new DbModels())
            {
                var prod = dbModels.Products.Where(x => x.ProductID == product.ProductID).FirstOrDefault();
                if (prod != null)
                {
                    dbModels.Products.Remove(prod);
                    dbModels.SaveChanges();
                }                
            }
            return RedirectToAction("ProductsList");
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}