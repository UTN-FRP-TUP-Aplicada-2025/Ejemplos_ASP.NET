using Ejemplo_CRUD_Simple_Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_CRUD_Simple_Login.Controllers;

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
    public async Task<IActionResult> Login(CuentaModel loginModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Nombre);

            if (user != null)
            {
                await _signInManager.SignOutAsync(); //cierra la session
                var result = await _signInManager.PasswordSignInAsync(user, loginModel.Clave, false, false);
                if (result.Succeeded)
                {
                    return Redirect(loginModel?.ReturnUrl ?? "/Home/Index");
                }
            }

            ModelState.AddModelError("", "Invalid name or password");
        }

        return View(loginModel); //vuelve al login
    }

    public async Task<RedirectResult> Logout(string returnUrl = "/")
    {
        await _signInManager.SignOutAsync();
        return Redirect(returnUrl);
    }
}
