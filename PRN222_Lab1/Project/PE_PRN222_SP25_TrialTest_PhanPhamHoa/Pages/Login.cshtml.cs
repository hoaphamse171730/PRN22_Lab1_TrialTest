using Business_Logic.Services;
using Data_Access.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;

namespace PharmaceuticalManagement_PhanPhamHoa.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AuthService _authService;

        public LoginModel(AuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public string EmailAddress { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Call the authentication service
            StoreAccount account = await _authService.AuthenticateAsync(EmailAddress, Password);

            if (account != null)
            {
                TempData["LoggedInUser"] = account.EmailAddress;
                return RedirectToPage("Index");
            }
            else
            {
                // Display an error message if authentication fails
                ErrorMessage = "You do not have permission to do this function!";
                return Page();
            }
        }
    }

}
