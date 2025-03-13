using EmployeeSecurityByUsingADO.Models;
using EmployeeSecurityByUsingADO.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSecurityByUsingADO.Controllers
{

   
    public class RegisterController : Controller
    {

        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] RegisterModel registerModel)
        {
            try
            {
                if (registerModel == null)
                {
                    return BadRequest("Invalid data received.");
                }

                bool isRegistered = _registerService.RegisterUser(registerModel);

                if (isRegistered)
                {
                    return Ok("Registration successful!");
                }
                else
                {
                    return BadRequest("Registration failed.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                List<RegisterModel> users = _registerService.GetAllUsers();
                if (users == null || users.Count == 0)
                {
                    return NotFound("No users found.");
                }
                return View(users);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching users: " + ex.Message);
            }

        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            try
            {
                RegisterModel user = _registerService.GetUserById(id);
                if (user == null)
                {
                    TempData["ErrorMessage"] = "User not found!";
                    return RedirectToAction("Index");
                }
                Console.Write(user);
                return View("Edit", user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while fetching user: " + ex.Message;
                return RedirectToAction("Index");
            }
        }


        [HttpPost("Update")]
        public IActionResult Update([FromBody] RegisterModel user)
        {
            try
            {
                bool isUpdated = _registerService.UpdateUser(user);
                if (isUpdated)
                {
                    return Ok("User updated successfully!");
                }
                else
                {
                    return StatusCode(500, "Failed to update user.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = _registerService.DeleteUser(id);
                if (isDeleted)
                {
                    return Ok("User deleted successfully!");
                }
                else
                {
                    return StatusCode(500, "Failed to delete user.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

















    }
}
