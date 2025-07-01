using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.database;

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
        public IActionResult Index()
        {
            var student = dbContext.Students.ToList();
            return View(student);
        }

    }
}
