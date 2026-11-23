using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TabletopMuster.Pages.Account;

// FRONTEND STUB: the form fields and validation rules below are what Login.cshtml binds to.
// Keep the property names, or change them together with the view.
// BACKEND TODO: inject SignInManager<...> and implement OnPostAsync.
public class LoginModel : PageModel
{
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

        // BACKEND TODO: sign the user in, for example:
        //   var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
        //   if (result.Succeeded) return LocalRedirect(Url.IsLocalUrl(ReturnUrl) ? ReturnUrl : "/");
        //   ModelState.AddModelError(string.Empty, "Invalid email or password.");
        // Errors added with an empty key are shown in the box at the top of the form.
        await Task.CompletedTask;
        return Page();
    }
}
