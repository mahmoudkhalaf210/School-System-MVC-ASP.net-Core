using Microsoft.AspNetCore.Mvc;
using Day2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Day2.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager; 
        }

        public RoleManager<IdentityRole> RoleManager { get; }

        public IActionResult Index()
        {
            return View(roleManager.Roles.ToList());
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(RoleViewModel roleVM)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole();

                identityRole.Name = roleVM.name;

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index");
                }

                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return View(roleVM);
        }
    }
}
