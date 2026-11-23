using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TabletopMuster.Pages;

// "/" is only a redirect: logged-in users go to the main page, everyone else to the login page.
public class IndexModel : PageModel
{
    public IActionResult OnGet()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToPage("/Home");
        }

        return RedirectToPage("/Account/Login");
    }
}
