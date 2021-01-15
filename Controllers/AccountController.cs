using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DemoStore.Models;
using DemoStore.ViewModels;
using System.Threading.Tasks;
using DemoStore.Components;

namespace DemoStore.Controllers
{

  [Authorize]
  public class AccountController : Controller
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;

    }

    [AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
      return View(new LoginViewModel
      {
        ReturnUrl = returnUrl
      });
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
      if (!ModelState.IsValid)
        return View(loginViewModel);

      var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

      if (user != null)
      {
        var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true, false);

        var isSigned = _signInManager.IsSignedIn(User);

        if (result.Succeeded)
        {
          if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
          {
            return RedirectToAction("Index", "Home");
          }

          return Redirect(loginViewModel.ReturnUrl);
        }
      }

      ModelState.AddModelError("", "Email/password not found");
      return View(loginViewModel);
    }

    [AllowAnonymous]
    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
      if (ModelState.IsValid)
      {
        var user = new AppUser { UserName = registerViewModel.Username, Email = registerViewModel.Email };
        var result = await _userManager.CreateAsync(user, registerViewModel.Password);

        if (result.Succeeded)
        {
          return RedirectToAction("Login", "Account");
        }
      }
      return View(registerViewModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
      await _signInManager.SignOutAsync();
      Thread.Sleep(1000);
      return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPassword()
    {
      return View();
    }
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
      if (ModelState.IsValid)
      {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
          return View("ForgotPasswordConfirmation");
        }
 
        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
        EmailService emailService = new EmailService();
        await emailService.SendEmailAsync(model.Email, "Reset Password",
          $"reset <a href='{callbackUrl}'>link</a>");
        return View("ForgotPasswordConfirmation");
      }
      return View(model);
    }
    [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPassword(string code = null)
    {
      return code == null ? View("ResetPasswordConfirmation") : View();
    }
 
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      var user = await _userManager.FindByEmailAsync(model.Email);
      if (user == null)
      {
        return View("ResetPasswordConfirmation");
      }
      var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
      if (result.Succeeded)
      {
        return View("ResetPasswordConfirmation");
      }
      foreach (var error in result.Errors)
      {
        ModelState.AddModelError(string.Empty, error.Description);
      }
      return View(model);
    }
  }
}