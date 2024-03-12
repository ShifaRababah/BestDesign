using BestDesign.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BestDesign.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            ViewBag.SumOfUsers = _context.Users.DefaultIfEmpty().Count();
            ViewBag.SumOfProducts = _context.Products.DefaultIfEmpty().Count();
            ViewBag.SumOfOrders = _context.Orders.DefaultIfEmpty().Count();
            ViewBag.SumOfContacts = _context.Contacts.DefaultIfEmpty().Count();
            return View();
        }
    }
}
