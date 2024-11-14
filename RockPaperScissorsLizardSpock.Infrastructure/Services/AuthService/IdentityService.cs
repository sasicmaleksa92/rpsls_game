using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RockPaperScissorsLizardSpock.Application.Exceptions;
using RockPaperScissorsLizardSpock.Application.Interfaces.AuthService;
using RockPaperScissorsLizardSpock.Infrastructure.Persistance.Identity;


namespace RockPaperScissorsLizardSpock.Infrastructure.Services.AuthService
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> SigninUserAsync(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);
            return result.Succeeded;

        }

        public async Task<(bool isSucceed, int userId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser()
            {
                UserName = userName
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new ValidationExceptionCustom(result.Errors);
            }

            return (result.Succeeded, user.Id);
        }


        public async Task<string> GetCheckedUserIdAsync(string userName, string password)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if (user == null)
            {
                throw new ValidationExceptionCustom("User name invalid");
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
            if (!isPasswordValid)
            {
                throw new ValidationExceptionCustom("Password invalid");
            }
            return await _userManager.GetUserIdAsync(user);
        }
    }
}
