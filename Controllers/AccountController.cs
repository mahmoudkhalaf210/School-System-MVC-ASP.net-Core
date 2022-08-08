using Day2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Day2.Models;

namespace Day2.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> sginInManager;
        ApplicationUser appUser = new ApplicationUser();
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn)
        {
            this.userManager = userManager;
            sginInManager = signIn;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            
            if(ModelState.IsValid)
            {
                appUser.UserName = newUserVM.userName;
                appUser.PasswordHash = newUserVM.password;
                appUser.address = newUserVM.address;

                IdentityResult result = await userManager.CreateAsync(appUser,newUserVM.password);

                if(result.Succeeded)
                {
                    IdentityResult result2 = await userManager.AddToRoleAsync(appUser, "student");
                    if(result2.Succeeded)
                    {
                        return View("logIn");
                    }
                    foreach(var err in result2.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }
                return View(newUserVM);
        }

        [HttpGet]
        public async Task<IActionResult> addminRegister()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> addminRegister(RegisterUserViewModel newAdminVM)
        {
            if (ModelState.IsValid)
            {
                appUser.UserName = newAdminVM.userName;
                appUser.address = newAdminVM.address;
                appUser.PasswordHash = newAdminVM.password;

                IdentityResult result = await userManager.CreateAsync(appUser, newAdminVM.password);

                if (result.Succeeded)
                {
                    IdentityResult result2 = await userManager.AddToRoleAsync(appUser, "admin");
                    
                    if(result2.Succeeded)
                    {
                        return RedirectToAction("logIn");
                    }

                    foreach(var err in result2.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
                
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
            }

            return  View(newAdminVM);
        }

        [HttpGet]
        public IActionResult logIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> logIn(LoginUserNameViewModel userVM)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(userVM.userName);

                if(user != null)
                {
                    bool pass = await userManager.CheckPasswordAsync(user, userVM.password);
                    if (pass)
                    {
                        await sginInManager.SignInAsync(user, userVM.rememberMe);
                        return RedirectToAction("Index", "Instructor");
                    }
                }
                ModelState.AddModelError("", "User Name OR Password Incorrect");
            }
            return View(userVM);
        }

        public IActionResult LogOut()
        {
            sginInManager.SignOutAsync();
            return RedirectToAction("logIn");
        }
    }
}
