using btlWebNC.Models.DTO;
using btlWebNC.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace btlWebNC.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
                this.authService = authService;
        }
        // we will create a user with a admin right, after that we are going to cmt this method because we need only 1 user in this application
        //and if you need other user, you can implement this registration method with view

        //public async Task<IActionResult> Register()
        //{
        //    var model = new RegistrationModel
        //    {
        //        Email = "user@gmai.com",
        //        Username = "user",
        //        Name = "User",
        //        Password = "Admin@123",
        //        PasswordConfirm = "Admin@123",
        //        Role = "user"
        //    };
        //    // if you want to register with user, change role = "user"
        //    var result = await authService.RegisterAsync(model);
        //    return Ok(result.Message);
        //}
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = "Could not logged in ...";
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
