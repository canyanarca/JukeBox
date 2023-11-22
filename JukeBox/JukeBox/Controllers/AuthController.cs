using JukeBox.Models.Entities;
using JukeBox.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;
using JukeBox.Migrations;
using JukeBox_API.Models.Entities;

namespace JukeBox.Controllers
{
    public class AuthController : Controller
    {

        string apiUrl = "http://localhost:5003/api/User/register";

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            apiUrl = "http://localhost:5003/api/User/login";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var loginData = new
                {
                    Username = model.UserName,
                    Password = model.Password
                };

                HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiUrl, loginData);

                if (response.IsSuccessStatusCode)
                {
                   
                    model.IsAuthenticated = true;

                    string userName = model.UserName;

                    return RedirectToAction("LoggedInIndex", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login credentials.");
                    return View(model);
                }
            }
        }

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            HttpResponseMessage response = await _httpClientFactory.CreateClient("MyApiClient").PostAsJsonAsync(apiUrl, model);

            if (response.IsSuccessStatusCode)
            {
                TempData["RegistrationSuccessMessage"] = "Registration was successful. Please log in.";

                return RedirectToAction("Login");
            }
            else
            {
                TempData["RegistrationFailedMessage"] = "Registration failed. Please try again later";
            }

            return View(model);
        }

        [Authorize] // Requires the user to be authenticated
        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {

            // Sign out the user and remove the authentication cookie
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect to the regular index page (replace with your actual route)
            return RedirectToAction("Index", "Home");


        }
    }
}
