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
        public IActionResult EnterName()
        {
            string? isLogin = HttpContext.Session.GetString("LoginName");
            if (isLogin is not null)
            {
                ViewBag.IsLogin = isLogin;
                HttpContext.Session.Remove("LoginName");
            }
            return View();
        }

        [HttpPost]
        public IActionResult EnterName(SessionName sessionName)
        {

            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("LoginName", sessionName.Name);
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
                List<FoodAds> foodAds = new List<FoodAds>
                {
                    new FoodAds{Id=1,Image="/images/ads3.png",Title= "Hot & Cheesy Pizza" ,Description= "Loaded with mozzarella, pepperoni, and fresh basil. Perfect for your cravings!", Price= 9.80f},
                    new FoodAds{Id=1,Image="/images/ads_barger.png",Title= "Smoky BBQ Burger" ,Description= "Juicy beef patty with smoky BBQ sauce, lettuce, and cheddar. Bite into flavor!", Price=9.98f},
                    new FoodAds{Id=1,Image="/images/ads2.png",Title= "Chilled Beverages" ,Description= "Cool off with our sparkling sodas, fruity mocktails, and classic cold drinks.", Price= 6.55f},
                };
                StudentsPageWithAds studentWithAds = new StudentsPageWithAds() { Student = student, FoodAds = foodAds };
                return View(studentWithAds);
            }

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {

            if (student is not null && ModelState.IsValid)
            {
                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();
                TempData["ms"] = $"{student.Name} has been Added.";
                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var record = dbContext.Students.Find(id);
            if (record == null)
                return RedirectToAction(nameof(Index));
            else return View(record);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var model = dbContext.Students.Find(student.Id);
            dbContext.Entry(model).CurrentValues.SetValues(student);
            dbContext.SaveChanges();
            TempData["ms"] = $"{student.Name} has been update.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Student student)
        {
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            TempData["ms"] = "Student has been Removed.";
            return RedirectToAction("Index");
        }

    }
}
