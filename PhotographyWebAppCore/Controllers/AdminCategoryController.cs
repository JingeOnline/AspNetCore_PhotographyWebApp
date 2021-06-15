﻿using Microsoft.AspNetCore.Mvc;
using PhotographyWebAppCore.Models;
using PhotographyWebAppCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPhotoRepository _photoRepository;

        public AdminCategoryController(ICategoryRepository categoryRepository,IPhotoRepository photoRepository)
        {
            _categoryRepository = categoryRepository;
            _photoRepository = photoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PhotoCategory> photoCategories = await _categoryRepository.GetAll();
            return View(photoCategories);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOne(bool isSuccess = false)
        {
            List<Photo> photos = await _photoRepository.GetAll();
            photos = photos.Where(x => x.AlbumId == null).ToList();
            ViewBag.Photos = photos;
            ViewBag.IsSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOne(PhotoCategory photoCategory)
        {
            if (ModelState.IsValid)
            {
                PhotoCategory newCategory = await _categoryRepository.CreateOne(photoCategory);
                if (newCategory != null)
                {
                    return RedirectToAction(nameof(CreateOne),new { isSuccess=true});
                }
            }
            ModelState.AddModelError("", "创建失败，内容不符合规范，请重新输入。");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _categoryRepository.DeleteById(id);
            return RedirectToAction(nameof(Index));
            //return Content(id.ToString());
        }
        [HttpGet]
        public async Task<IActionResult> UpdateById(int id, bool isSuccess = false)
        {
            List<Photo> photos = await _photoRepository.GetAll();
            photos = photos.Where(x => x.AlbumId == null).ToList();
            ViewBag.Photos = photos;

            PhotoCategory photoCategory = await _categoryRepository.GetById(id);
            ViewBag.IsSuccess = isSuccess;
            return View(photoCategory);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateById(PhotoCategory photoCategory)
        {
            PhotoCategory category = await _categoryRepository.UpdateOne(photoCategory);
            return RedirectToAction(nameof(UpdateById), new { isSuccess = true, id = category.Id });
        }
    }
}
