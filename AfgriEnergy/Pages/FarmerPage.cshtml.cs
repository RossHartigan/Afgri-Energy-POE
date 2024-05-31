using AfgriEnergy.Data;
using AfgriEnergy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AfgriEnergy.Pages
{
    public class FarmerPageModel : PageModel
    {
        private readonly AfgriEnergyContext _context;
        private readonly ILogger<FarmerPageModel> _logger;

        public FarmerPageModel(AfgriEnergyContext context, ILogger<FarmerPageModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Product> ProductList { get; set; }
        public IList<User> UserList { get; set; }
        public int DefaultUserID { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            ProductList = await _context.Product.ToListAsync();
            UserList = await _context.User.ToListAsync();

            int? userID = HttpContext.Session.GetInt32("UserID");//get user ID from session
            DefaultUserID = userID ?? 1;

            return Page();
        }

        public IActionResult OnPostAddProduct()
        {

            var productName = Request.Form["productName"];
            var category = Request.Form["category"];
            var tempDate = Request.Form["productionDate"];

            DateTime productionDate = DateTime.Parse(tempDate);

            int? userID = HttpContext.Session.GetInt32("UserID");//get user ID from session
            int defaultUserId = userID ?? 1;

            var product = new Product
            {
                UserID = defaultUserId,
                ProductName = productName,
                Category = category,
                ProductionDate = productionDate
            };

            _context.Product.Add(product);
            _context.SaveChanges();

            return RedirectToPage("/FarmerPage"); ;
        }
    }
}
