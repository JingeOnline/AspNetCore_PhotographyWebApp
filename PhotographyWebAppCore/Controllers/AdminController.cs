using Microsoft.AspNetCore.Mvc;
using PhotographyWebAppCore.Models;
using PhotographyWebAppCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AdminController(IAccountRepository accountRepository,ICategoryRepository categoryRepository)
        {
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Administrator model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _accountRepository.SignInAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "用户名或密码错误");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Category()
        {
            List<PhotoCategory> photoCategories = await _categoryRepository.GetAll();
            return View(photoCategories);
        }
    }
}
