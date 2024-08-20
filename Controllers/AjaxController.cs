using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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


        public IActionResult GetEmp()
        {
            var data = db.Emps.ToList();
            return Json(data);
        }
        
        public IActionResult DelEmp(int id)
        {
            var data = db.Emps.Find(id);
            db.Emps.Remove(data);
            db.SaveChanges();
            return Json("");
        }
        [HttpPost]
        public IActionResult updateEmp(Emp e)
        {
            //var data = db.Emps.Find(id);
            db.Emps.Update(e);
            db.SaveChanges();
            return Json("");
        }
        
        public IActionResult EditEmp(int id)
        {
            var data = db.Emps.Find(id);
           
            return Json(data);
        }
        [HttpPost]
        public IActionResult Index(string Search)
        {
            if (Search.IsNullOrEmpty())
            {
                var data = db.Emps.ToList();
                return Json(data);
            }
            else
            {
                var data = db.Emps.Where(a => a.Name.Contains(Search) || a.Email.Contains(Search)
                            || a.Salary.ToString().Contains(Search)).ToList();
                return Json(data);
            }
        }
    }
}
