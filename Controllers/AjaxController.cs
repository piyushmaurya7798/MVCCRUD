using Microsoft.AspNetCore.Mvc;
using MVCCRUD.Context;
using MVCCRUD.Models;

namespace MVCCRUD.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ApplicationDbContext db;

        public AjaxController(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            db.Emps.Add(e);
            db.SaveChanges();
            return Json("");
        }
    }
}
