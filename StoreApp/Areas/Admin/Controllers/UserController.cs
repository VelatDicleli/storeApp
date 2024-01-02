using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Abstract;
using StoreApp.Entities.Dtos;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _services;
        public UserController(IServiceManager _services)
        {
            this._services = _services;

        }
        public IActionResult Index()
        {
            var users = _services.AuthService.GetAllUsers();
            return View(users);
        }


        public IActionResult Create()
        {
            return View(new UserDtoForCreation()
            {
                Roles = new HashSet<string>(_services
                    .AuthService
                    .Roles
                    .Select(r => r.Name)
                    .ToList())
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDtoForCreation userDto)
        {
            var result = await _services.AuthService.CreateUser(userDto);
            return result.Succeeded
                ? RedirectToAction("Index")
                : View();
        }


        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            var user = await _services.AuthService.GetOneUserForUpdate(id);
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDto)
        {
            if (ModelState.IsValid)
            {
                await _services.AuthService.Update(userDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id)
        {
            return View(new ResetPasswordDto()
            {
                UserName = id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto model)
        {
            var result = await _services.AuthService.ResetPassword(model);
            return result.Succeeded
                ? RedirectToAction("Index")
                : View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOneUser([FromForm] UserDto userDto)
        {
            var result = await _services
                .AuthService
                .DeleteOneUser(userDto.UserName);

            return result.Succeeded
                ? RedirectToAction("Index")
                : View();
        }
    }


}
