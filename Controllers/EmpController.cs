using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MVCCRUD.Context;
using MVCCRUD.Models;

namespace MVCCRUD.Controllers
{
    public class EmpController : Controller
    {
        private ApplicationDbContext db;

        public EmpController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var d = db.Emps.ToList();
            return View(d);
        }
        public IActionResult AddEmp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            db.Emps.Add(e);
            db.SaveChanges();
            TempData["msg"] = "Emp added Successfully";
            return RedirectToAction("Index");
        }
        
        public IActionResult DeleteEmp(int id)
        {
            var d=db.Emps.Find(id);

            db.Emps.Remove(d);
            db.SaveChanges();
            TempData["msgDel"] = "Emp Deleted Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult UpdateEmp(int id) 
        {
            var data=db.Emps.Find(id);
            return View(data);

        }
        [HttpPost]
        public IActionResult UpdateEmp(Emp e) 
        {
            db.Emps.Update(e);
            db.SaveChanges();
            TempData["msg"] = "Emp Updated Successfully";
            return RedirectToAction("Index");

        }


        [HttpPost]
        public ActionResult BatchDelete(int[] deleteInputs)
        {
            if (deleteInputs != null && deleteInputs.Length > 0)
            {
                foreach (var item in deleteInputs)
                {
                    var data = db.Emps.Find(item);
                    db.Emps.RemoveRange(data);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Index(string Search)
        {
            if (Search.IsNullOrEmpty())
            {
                var data = db.Emps.ToList();
                return View(data);
            }
            else
            {
                var data = db.Emps.Where(a => a.Name.Contains(Search) || a.Email.Contains(Search) || a.Salary.ToString().Contains(Search)).ToList();
                return View(data);
            }
        }

    }
}
