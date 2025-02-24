using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

[Route("auth")]
public class AuthController : Controller
{
    [HttpGet("github")]
    public IActionResult GitHubLogin()
    {
        var redirectUrl = Url.Action("GitHubCallback", "Auth");
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl ?? "/" };
        return Challenge(properties, "GitHub");
    }

    [HttpGet("github/callback")]
    public async Task<IActionResult> GitHubCallback()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        if (!result.Succeeded)
        {
            return BadRequest("Failed to authenticate with GitHub.");
        }

        var claims = result.Principal?.Identities.FirstOrDefault()?.Claims
            .Select(c => new { c.Type, c.Value });

        return Redirect("/");
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/");
    }
}
