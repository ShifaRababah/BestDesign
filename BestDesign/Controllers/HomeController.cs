using BestDesign.Data;
using BestDesign.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BestDesign.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
           
        }

        public async Task<IActionResult> Index2()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult FilterByDate()
        {
            var products = _context.Products.OrderByDescending(x=>x.Date).ToList();
            return View(products);

        }
        public IActionResult FilterByPrice()
        {
            var products = _context.Products.OrderByDescending(x => x.Price).Take(2).ToList();
            return View(products);

        }
        public IActionResult GetProductsByUser(string id)
        {
            var products = _context.Products.Where(x => x.UserId == id).ToList();
            return View(products);
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult FAQ()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProductSearch(string xname)
        {
            var products = _context.Products.Where(x => x.Title.Contains(xname)).ToList();
            return View(products);

        }




        [Authorize]
        public IActionResult AddProductToCart(int id)
        {
            var price = _context.Products.Find(id).Price;

            var item = _context.Carts.FirstOrDefault(x => x.ProductId == id && x.UserId == User.Identity.Name);

        
                _context.Carts.Add(new Cart
                {
                    ProductId = id,
                    UserId = User.Identity.Name,
                    Date = DateTime.Now,    
                  
                });
           
            _context.SaveChanges();


            return Redirect("~/Carts/Index");

        }

        [Authorize]
        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            Order o = new Order
            {
                Email = order.Email,
                Name = order.Name,
                Phone = order.Phone,
                Date= DateTime.Now,
                UserId = User.Identity.Name
            };

            var cartItem = _context.Carts.Where(x => x.UserId == User.Identity.Name).ToList();

            _context.Carts.RemoveRange(cartItem);
            _context.Orders.Add(o);
            _context.SaveChanges();

            return Redirect("~/Carts/Index");

        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}