using System.Linq;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [ValidateInput(false)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new ShoppingListDbContext())
            {
                var allProducts = db.Products.ToList();

                return View(allProducts);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product productToCreate)
        {
            if (productToCreate == null)
            {
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(productToCreate.Name)
                || productToCreate.Quantity <= 0
                || productToCreate.Priority <= 0)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ShoppingListDbContext())
            {
                db.Products.Add(productToCreate);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ShoppingListDbContext())
            {
                var productToEdit = db.Products.Find(id);

                if (productToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                return View(productToEdit);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Product productModel)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ShoppingListDbContext())
            {
                var productToEdit = db.Products.Find(id);

                if (productToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                if (string.IsNullOrWhiteSpace(productToEdit.Name) ||
                string.IsNullOrWhiteSpace(productToEdit.Status)
                || productModel.Quantity <= 0
                || productModel.Priority <= 0)
                {
                    return RedirectToAction("Index");
                }

                db.Products.Find(id).Name = productModel.Name;
                db.Products.Find(id).Priority = productModel.Priority;
                db.Products.Find(id).Quantity = productModel.Quantity;
                db.Products.Find(id).Status = productModel.Status;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}