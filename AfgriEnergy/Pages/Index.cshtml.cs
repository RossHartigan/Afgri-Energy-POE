using AfgriEnergy.Data;
using AfgriEnergy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AfgriEnergy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AfgriEnergyContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, AfgriEnergyContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnPostLogin()
        {
            var email = Request.Form["email"];
            var password = Request.Form["password"];
            
            List<User> users = _context.User.ToList();

            foreach (var x in users)
            {
                if (x.Email == email && x.Password == password)
                {
                    // Set session variable for user ID
                    HttpContext.Session.SetInt32("UserID", x.UserID);

                    if (x.Farmer)
                    {
                        _logger.LogInformation("Farmer Logged In");
                        return RedirectToPage("/FarmerPage");
                    }
                    else if (x.Employee)
                    {
                        _logger.LogInformation("Employee Logged In");
                        return RedirectToPage("/EmployeePage");
                    }
                    else
                    {
                        _logger.LogInformation("Invalid user Type");
                    }
                }
                else
                {
                    _logger.LogInformation("Invalid Username or Password!");
                }
            }

            return Page();
        }
    }
}