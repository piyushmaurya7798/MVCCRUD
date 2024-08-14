using Microsoft.AspNetCore.Mvc;
using MVCCRUD.Context;
using MVCCRUD.Models;

namespace MVCCRUD.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        private IWebHostEnvironment env;

        public ProductController(ApplicationDbContext db,IWebHostEnvironment env)
        {
            this.db = db;
        this.env = env;
        }
        public IActionResult Index()
        {
            var data=db.Products.ToList();
            return View(data);
        }
        
        public IActionResult AddProduct()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel pv)
        {
            var path = env.WebRootPath;
            var filePath = "Content/Images" + pv.picture.FileName;
            var fullPath = Path.Combine(path, filePath);
            UploadFile(pv.picture,fullPath);
            var obj = new Product()
            {
                pname = pv.pname,
                pcat = pv.pcat,
                picture = filePath,
                price = pv.price,
            };
            db.Products.Add(obj);
            db.SaveChanges();
            TempData["msg"] = "Added Successfully..!";
            return RedirectToAction("Index");
        }

        private void UploadFile(IFormFile picture, string fullPath)
        {
            FileStream f = new FileStream(fullPath, FileMode.Create);
            picture.CopyTo(f);
        }
    }
}
