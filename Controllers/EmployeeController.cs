using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEmployeeMVC.Data;
using StudentEmployeeMVC.Models;

namespace StudentEmployeeMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        /*public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _db.Students;
            return View(objStudentList);
        }*/

        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var employees = from s in _db.Employees
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.FirstName.Contains(searchString));
            }
            return View(await employees.AsNoTracking().ToListAsync());
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employeeFromDb = _db.Employees.Find(id);

            if (employeeFromDb == null)
            {
                return NotFound();
            }

            return View(employeeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employeeFromDb = _db.Employees.Find(id);

            if (employeeFromDb == null)
            {
                return NotFound();
            }

            return View(employeeFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Employee deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
