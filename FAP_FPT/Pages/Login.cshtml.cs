using FAP_FPT.Business.IRepository;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FAP_FPT.Business.DTO;
using System.Security.Claims;
using FAP_FPT.DataAccess.Models;

namespace FAP_FPT.Pages
{
    public class LoginModel : PageModel
    {
        private IUserRepository _userRepository;

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostLoginByGoogle()
        {
            string authenticationScheme = GoogleDefaults.AuthenticationScheme;

            var auth = new AuthenticationProperties
            {
                RedirectUri = Url.Page("/Login", pageHandler: "LoginGoogleCallback")
            };
            return new ChallengeResult(authenticationScheme, auth);
        }

        public async Task<IActionResult> OnGetLoginGoogleCallbackAsync()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync("Google");

            if (!authenticateResult.Succeeded)
                return BadRequest(); // TODO: Handle this better.

            var userId = authenticateResult.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var userEmail = authenticateResult.Principal.FindFirstValue(ClaimTypes.Email);

            UserDTO loginedUser = _userRepository.GetUserByEmail((string)userEmail);
            if(loginedUser == null)
            {
                TempData["ErrorMessage"] = "Tài khoản của bạn không được phép đăng nhập vào hệ thống";
                return Page();
            }
            HttpContext.Session.SetInt32("userId", loginedUser.Id);
            return LocalRedirect("/Student/StudenSchedule");
        }
    }
}
