using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TabletopMuster.Pages.Account;

// FRONTEND STUB: the form fields and validation rules below are what Register.cshtml binds to.
// Keep the property names, or change them together with the view.
// BACKEND TODO: inject UserManager<...> / SignInManager<...> and implement OnPostAsync.
public class RegisterModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? ReturnUrl { get; set; }

    public class InputModel
    {
        [Required(ErrorMessage = "Choose a username.")]
        [StringLength(32, MinimumLength = 3, ErrorMessage = "Username must be 3 to 32 characters long.")]
        [Display(Name = "Username")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter your email.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        // Identity's default password rules: 6+ characters, upper and lower case, a digit and a symbol.
        // If the backend changes them, update the hint text in Register.cshtml too.
        [Required(ErrorMessage = "Choose a password.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Repeat your password.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // BACKEND TODO: create the user and sign them in, for example:
        //   var user = new IdentityUser { UserName = Input.UserName, Email = Input.Email };
        //   var result = await _userManager.CreateAsync(user, Input.Password);
        //   if (result.Succeeded) { await _signInManager.SignInAsync(user, isPersistent: false); return LocalRedirect(...); }
        //   foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
        // Errors added with an empty key are shown in the box at the top of the form.
        await Task.CompletedTask;
        return Page();
    }
}
