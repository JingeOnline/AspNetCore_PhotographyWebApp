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
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(PhotoCategory photoCategory)
        {
            if (ModelState.IsValid)
            {
                PhotoCategory newCategory = await _categoryRepository.CreateOne(photoCategory);
                if (newCategory != null)
                {
                    return RedirectToAction(nameof(Category));
                }
            }
            ModelState.AddModelError("", "创建失败，内容不符合规范，请重新输入。");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteById(id);
            return RedirectToAction(nameof(Category));
            //return Content(id.ToString());
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id,bool isSuccess=false)
        {
            PhotoCategory photoCategory = await _categoryRepository.GetById(id);
            ViewBag.IsSuccess = isSuccess;
            return View(photoCategory);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(PhotoCategory photoCategory)
        {
            PhotoCategory category = await _categoryRepository.UpdateOne(photoCategory);
            return RedirectToAction(nameof(UpdateCategory), new { isSuccess = true, id = category.Id });
        }
    }
}
