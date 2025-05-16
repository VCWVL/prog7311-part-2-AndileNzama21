// Controllers/FarmerController.cs
using Microsoft.AspNetCore.Mvc;
using PROG.Data;
using PROG.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace AgriEnergyConnect.Controllers
{
    public class FarmerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmerController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Displays a list of all farmers
        public IActionResult ListFarmers
        {
            get
            {
                var farmers = _context.Farmers.ToList();
                return View(farmers);
            }
        }

        


        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult AddFarmer(Farmer farmer)
{
    if (ModelState.IsValid)
    {
        if (_context.Farmers.Any(f => f.Email == farmer.Email))
        {
            ModelState.AddModelError("Email", "Email already registered");
            return View(farmer);
        }

        
        try
        {
            _context.Farmers.Add(farmer);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Farmer added successfully!";
            return RedirectToAction("ListFarmers"); // ✅ Redirect here
        }
        catch
        {
            ModelState.AddModelError("", "Failed to save farmer. Please try again.");
        }
    }
    return View(farmer);
}

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserRole") != "Farmer")
                return RedirectToAction("Login", "Account");

            string email = HttpContext.Session.GetString("UserEmail");
            var farmer = _context.Farmers.FirstOrDefault(f => f.Email == email);

            if (farmer == null) return View("NotRegistered");

            var products = _context.Products.Where(p => p.FarmerId == farmer.FarmerId).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            if (HttpContext.Session.GetString("UserRole") != "Farmer")
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            string email = HttpContext.Session.GetString("UserEmail");
            var farmer = _context.Farmers.FirstOrDefault(f => f.Email == email);

            if (farmer != null && ModelState.IsValid)
            {
                product.FarmerId = farmer.FarmerId;
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            return View(product);
        }
    }
}
