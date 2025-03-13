using EmployeeSecurityByUsingADO.Data;
using EmployeeSecurityByUsingADO.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSecurityByUsingADO.Controllers
{
    public class LogController : Controller
    {

        private readonly IAuthService _authService;

        public LogController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertLogin(string username, string password)
        {

            if (_authService.ValidateAdmin(username, password))
                return RedirectToAction("");

            ViewBag.Message = "Invalid Password";
            return View();
        }
    }
}
