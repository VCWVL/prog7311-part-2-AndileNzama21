using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG.Data;
using PROG.Models;

public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
{
    if (HttpContext.Session.GetString("UserRole") != "Employee")
        return RedirectToAction("Login", "Account");

    var farmers = _context.Farmers.ToList(); // Get all farmers
    return View(farmers); // Pass the list to the view
}
    

    public IActionResult ListFarmers()
    {
        if (HttpContext.Session.GetString("UserRole") != "Employee")
            return RedirectToAction("Login", "Account");

        var farmers = _context.Farmers.ToList();
        return View(farmers);
    }

    [HttpGet]
    public IActionResult AddFarmer()
    {
        if (HttpContext.Session.GetString("UserRole") != "Employee")
            return RedirectToAction("Login", "Account");

        return View();
    }


[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult AddFarmer(Farmer farmer)
{
    if (ModelState.IsValid)
    {
        _context.Farmers.Add(farmer);      // ✅ Save farmer
        _context.SaveChanges();            // ✅ Save to DB

        TempData["SuccessMessage"] = "Farmer added successfully!";
        return RedirectToAction("Dashboard");
    }

    return View(farmer); // Show form with validation errors


 

    // Log validation errors (for debugging)
    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
    {
        Console.WriteLine(error.ErrorMessage);
    }

    return View(farmer); // Return the model with validation messages
}


    public IActionResult ViewProducts(int farmerId, string productType, DateTime? startDate, DateTime? endDate)
    {
        var products = _context.Products.Where(p => p.FarmerId == farmerId);

        if (!string.IsNullOrEmpty(productType))
            products = products.Where(p => p.Category == productType);

        if (startDate.HasValue)
            products = products.Where(p => p.ProductionDate >= startDate.Value);

        if (endDate.HasValue)
            products = products.Where(p => p.ProductionDate <= endDate.Value);

        ViewBag.Farmer = _context.Farmers.Find(farmerId);
        return View(products.ToList());
    }
}

