using Ejemplo_Login_Simple.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_Login_Simple.Controllers;

[Authorize]
public class CuentaController : Controller
{
    private UserManager<IdentityUser> _userManager;
    private SignInManager<IdentityUser> _signInManager;

    public CuentaController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    private readonly List<IdentityUser> _users = new();


    public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        if (_users.Any(u => u.NormalizedUserName == user.NormalizedUserName))
        {
            return Task.FromResult(IdentityResult.Failed(new IdentityError
            {
                Code = "DuplicateUserName",
                Description = "El nombre de usuario ya existe."
            }));
        }

        _users.Add(user);
        return Task.FromResult(IdentityResult.Success);
    }

    [AllowAnonymous]
    async public Task<ViewResult> Login(string ReturnUrl)
    {
        return View(new CuentaModel
        {
            ReturnUrl = ReturnUrl
        });
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(CuentaModel cuentaModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(cuentaModel.Name);

            if (user != null)
            {
                await _signInManager.SignOutAsync(); //cierra la session
                var result = await _signInManager.PasswordSignInAsync(user, cuentaModel.Password, false, false);
                if (result.Succeeded)
                {
                    return Redirect(cuentaModel?.ReturnUrl ?? "/Home/Index");
                }
            }

            ModelState.AddModelError("", "Invalid name or password");
        }

        return View(cuentaModel); //vuelve al login
    }

    public async Task<RedirectResult> Logout(string returnUrl = "/")
    {
        await _signInManager.SignOutAsync();
        return Redirect(returnUrl);
    }
}
