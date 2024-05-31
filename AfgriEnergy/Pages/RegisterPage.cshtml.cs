using AfgriEnergy.Data;
using AfgriEnergy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AfgriEnergy.Pages
{
    public class RegisterPageModel : PageModel
    {
        private readonly AfgriEnergyContext _context;
        private readonly ILogger<RegisterPageModel> _logger;

        public RegisterPageModel(AfgriEnergyContext context, ILogger<RegisterPageModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnPostRegister()
        {

            var email = Request.Form["email"];
            var name = Request.Form["firstName"];
            var surname = Request.Form["lastName"];
            var password = Request.Form["password"];
            var passwordConfirm = Request.Form["confirmPassword"];
            var role = Request.Form["role"];

            string finalPassword = null;

            if (password != passwordConfirm)
            {
                return RedirectToPage("/RegisterPage");
            }
            else
            {
                finalPassword = password;
            }

            bool farmer = false;
            bool employee = false;

            if (role == "Farmer")
            {
                farmer = true;
            }
            else if (role =="Employee")
            {
                employee = true;
            }

            var user = new User
            {
                Email = email,
                Name = name,
                Surname = surname,
                Password = finalPassword,
                Farmer = farmer,
                Employee = employee
            };

            _context.User.Add(user);
            _context.SaveChanges();


            return RedirectToPage("/Index");
        }
    }
}
