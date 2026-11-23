using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace TabletopMuster.Pages.Account;

// FRONTEND STUB: the form fields and validation rules below are what Login.cshtml binds to.
// Keep the property names, or change them together with the view.
// BACKEND TODO: inject SignInManager<...> and implement OnPostAsync.
public class LoginModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public LoginModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    // Where to send the user after a successful login (set by the auth redirect, e.g. ?ReturnUrl=/ArmyLists).
    [BindProperty(SupportsGet = true)]
    public string? ReturnUrl { get; set; }

    public class InputModel
    {
        [Required(ErrorMessage = "Enter your email.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
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

        var user = await _userManager.FindByEmailAsync(Input.Email);

        if(user is not null) {
            var result = await _signInManager.PasswordSignInAsync(
                user, Input.Password, Input.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded) {
                return LocalRedirect(Url.IsLocalUrl(ReturnUrl) ? ReturnUrl! : "/");
            }

            if (result.IsLockedOut) {
                ModelState.AddModelError(string.Empty, "Too many failed attempts. Try again in a few minutes");
                return Page();
            }
        }

        ModelState.AddModelError(string.Empty, "Invalid email or password");
        return Page();
    }
}
