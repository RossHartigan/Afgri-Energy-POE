using AfgriEnergy.Data;
using AfgriEnergy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AfgriEnergy.Pages
{
    public class EmployeePageModel : PageModel
    {
        private readonly AfgriEnergyContext _context;
        private readonly ILogger<EmployeePageModel> _logger;

        public EmployeePageModel(AfgriEnergyContext context, ILogger<EmployeePageModel> logger)
        {
            _context = context;
            _logger = logger;
        }  
        
        public IList<Product> ProductList { get; set; }
        public IList<User> UserList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            ProductList = await _context.Product.ToListAsync();
            UserList = await _context.User.ToListAsync();   

            return Page();
        }

        public IActionResult OnPostAddFarmer()
        {

            var email = Request.Form["email"];
            var name = Request.Form["firstName"];
            var surname = Request.Form["surname"];
            var password = Request.Form["password"];

            var user = new User
            {
                Email = email,
                Name = name,
                Surname = surname,
                Password = password,
                Farmer = true,
                Employee = false
            };

            _context.User.Add(user);
            _context.SaveChanges();

            return RedirectToPage("/EmployeePage"); ;
        }
    }
}
