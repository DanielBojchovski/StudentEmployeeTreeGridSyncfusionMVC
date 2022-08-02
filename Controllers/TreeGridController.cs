using Microsoft.AspNetCore.Mvc;
using StudentEmployeeMVC.Data;

namespace StudentEmployeeMVC.Controllers
{
    public class TreeGridController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TreeGridController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var order = _db.TasksToDo;
            ViewBag.dataSource = order;
            return View();
        }
    }
}
