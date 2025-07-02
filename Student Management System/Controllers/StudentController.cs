using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.database;
using Student_Management_System.Models;
using Student_Management_System.Models.Entity;

namespace Student_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly SMSDbContext dbContext;

        public StudentController(SMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult EnterName() {
            string? isLogin = HttpContext.Session.GetString("LoginName");
            if (isLogin is not null) {
                ViewBag.IsLogin = isLogin;
                HttpContext.Session.Remove("LoginName");
            }
            return View();
        }

        [HttpPost]
        public IActionResult EnterName(SessionName sessionName) {

            if (ModelState.IsValid) {
                HttpContext.Session.SetString("LoginName",sessionName.Name);
                return RedirectToAction("Index");
            }
            return View(sessionName);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? isLogin = HttpContext.Session.GetString("LoginName");
            if (isLogin == null)
            {
                return RedirectToAction("EnterName");
            }
            else
            {
                ViewBag.SessionData = isLogin;
                var student = await dbContext.Students.ToListAsync();
                return View(student);
            }
               
        }

        [HttpGet]
        public IActionResult Add()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Student student) {

            if(student is not null && ModelState.IsValid)
            {
                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();
                TempData["std_added"] = student.Name;
                return RedirectToAction("Index");
            }

            return View(student);
        }

    }
}
