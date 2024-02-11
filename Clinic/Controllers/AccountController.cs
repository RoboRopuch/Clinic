using Clinic.Models.Domain_Entities;
using Clinic.Models.ViewModels;
using Clinic.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.Reflection.Metadata.Ecma335;

namespace Clinic.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public SignInManager<IdentityUser> SignInManager { get; }
        public IPatientRepository PatientRepository { get; }

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IPatientRepository patientRepository)
        {
            this.userManager = userManager;
            SignInManager = signInManager;
            PatientRepository = patientRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email,

            };

            var identityResult = await userManager.CreateAsync(identityUser, registerViewModel.Password);

            if (identityResult.Succeeded)
            {
                var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "PreUser");


                if (roleIdentityResult.Succeeded)
                {

                    var patientToAdd = new Patient
                    {
                        UserId = identityUser.Id,
                        Name = registerViewModel.Name,
                        Surname = registerViewModel.Surname
                    };

                    await PatientRepository.AddAsync(patientToAdd);


                    return RedirectToAction("Index", "Home");
                }
                
            }

            return View("Register");
        }

        [HttpGet]
        public IActionResult Login() {
 

            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteAccount()
        {
            var user = await userManager.GetUserAsync(User);

            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("List");
        }
         


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var signInResult = await SignInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, false);

            if (signInResult.Succeeded && signInResult != null) {

                return RedirectToAction("Index", "Home");

            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> ListUsers()
        {
            var usersInUserRole = await userManager.GetUsersInRoleAsync("User");
            var singleRoleUsers = usersInUserRole
                .Where(user => userManager.GetRolesAsync(user).Result.Count == 1)
                .ToList();

            return View(singleRoleUsers);
        }

        [HttpGet]
        public async Task<IActionResult> ListPreUsers()
        {
            var preUsersInPreUserRole = await userManager.GetUsersInRoleAsync("PreUser");

            var singleRolePreUsers = preUsersInPreUserRole
                .Where(user => userManager.GetRolesAsync(user).Result.Count == 1)
                .ToList();


            return View(singleRolePreUsers);
        }


        [HttpGet]

        public async Task<IActionResult> GiveUserRole(Guid Id) 
        {

            var preUser = await userManager.FindByIdAsync(Id.ToString());


            if (preUser != null)
            {
                var preUserRoles = await userManager.GetRolesAsync(preUser);
                await userManager.RemoveFromRolesAsync(preUser, preUserRoles);
                var result = await userManager.AddToRoleAsync(preUser, "User");

                if (result.Succeeded)
                {

                    return RedirectToAction("ListPreUsers");
                }
                else {

                    return View("Error");
                
                }


            }
            else { 
                return View("Error");
            }
           
        }


    } 
}
