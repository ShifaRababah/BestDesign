using BestDesign.Data;
using BestDesign.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BestDesign.Controllers
{
    public class EmployeeController : Controller
    {
      
       private readonly ApplicationDbContext _context;


        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;

        }
        [Authorize(Roles = "Employee")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SaveStartTime(TimeSheet timeSheet)
        {
        
           
            timeSheet.UserId = User.Identity.Name;
            timeSheet.StartTime = DateTime.Now;

            _context.TimeSheets.Add(timeSheet);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveEndTime(TimeSheet timeSheet)
        {

            //int empId = (int)HttpContext.Session.GetInt32("EmpId");

            //var row = _context.TimeSheets.Where(s => s.UserId == User.Identity.Name && s.EndTime == null).SingleOrDefault();

            timeSheet.UserId = User.Identity.Name;
            timeSheet.EndTime = DateTime.Now;
            _context.TimeSheets.Add(timeSheet);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
