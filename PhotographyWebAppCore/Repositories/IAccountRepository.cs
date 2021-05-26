using Microsoft.AspNetCore.Identity;
using PhotographyWebAppCore.Models;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(Administrator signInModel);
        Task<SignInResult> SignInAsync(Administrator signInModel);
        Task SignOutAsync();
    }
}