using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRFrontend.Dtos.IdentityDtos;

namespace SignalRFrontend.Controllers
{
    public class AdminSettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminSettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);

            UserEditDto userEditDto = new UserEditDto();
            userEditDto.Name = value.Name;
            userEditDto.Surname = value.Surname;
            userEditDto.Mail = value.Email;
            userEditDto.Username = value.UserName;

            return View(userEditDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if(userEditDto.Password == userEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDto.Name;
                user.Surname = userEditDto.Surname;
                user.Email = userEditDto.Mail;
                user.UserName = userEditDto.Username;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);
                var result = await _userManager.UpdateAsync(user);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","AdminCategory");
                }
            }
            return View();
        }
    }
}
