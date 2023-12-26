using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoenixMerch.Business.Abstract;
using PhoenixMerch.Entities.Dtos;
using Sentry;

namespace PhoenixMerch.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;


        IOrderProcessService _orderProcessService;


        public AccountController(IAuthService authService, IOrderProcessService orderProcessService)
        {
            _orderProcessService = orderProcessService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                string ass = User.Identity.Name;
                var result = await _authService.Login(loginDto);
                if (result.Succeeded)
                {
                    var user = _authService.GetUserByEmail(loginDto.Email);
                    var role = await _authService.GetRoleByUserName(user.UserName);
                    switch (role)
                    {
                        case "Customer": return RedirectToAction("Index", "Home");
                        default: return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz!");
            return View(loginDto);
        }
        
        [HttpGet]
        public IActionResult CustomerRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CustomerRegister(CustomerRegisterDto customerRegisterDto)
        {
            IdentityResult result = _authService.CustomerRegister(customerRegisterDto).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz!");
            return View(customerRegisterDto);
        }
        public async Task<IActionResult> LogOut()
        {
            await _authService.Logout();
            return RedirectToAction("Login");
        }
    }
}
