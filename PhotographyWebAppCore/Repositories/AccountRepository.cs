using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PhotographyWebAppCore.Models;

namespace PhotographyWebAppCore.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        //用来实现用户注册的功能
        private readonly UserManager<IdentityUser> _userManager;
        //用来实现用户登录的功能
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //用户登录
        public async Task<SignInResult> SignInAsync(Administrator signInModel)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(
                signInModel.UserName,
                signInModel.Password,
                signInModel.RememberMe,
                false);
            return result;
        }
        //用户登出
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        //注册用户
        public async Task<IdentityResult> CreateUserAsync(Administrator signInModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = signInModel.UserName,
            };
            IdentityResult result = await _userManager.CreateAsync(user, signInModel.Password);
            return result;
        }

    }
}
