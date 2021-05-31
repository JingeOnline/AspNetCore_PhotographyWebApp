﻿using Microsoft.AspNetCore.Mvc;
using PhotographyWebAppCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotographyWebAppCore.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using PhotographyWebAppCore.Helpers;

namespace PhotographyWebAppCore.Controllers
{
    public class AdminPhotoController : Controller
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminPhotoController(IPhotoRepository photoRepository, IWebHostEnvironment webHostEnvironment)
        {
            _photoRepository = photoRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Photo()
        {
            List<Photo> photos = await _photoRepository.GetAll();
            return View(photos);
        }
        [HttpGet]
        public IActionResult AddOnePhoto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOnePhoto(Photo photo)
        {
            if (ModelState.IsValid && photo.PhotoFile != null)
            {
                //把照片储存到本地文件夹
                string[] pairs = photo.PhotoFile.FileName.Split('.');
                string extension = pairs[pairs.Length - 1];
                string uniqueFileName = Guid.NewGuid().ToString() + "." + extension;
                string folder = "images/photos_origional";
                string rootPath = _webHostEnvironment.WebRootPath;
                string filePath = Path.Combine(rootPath, folder, uniqueFileName);
                await photo.PhotoFile.CopyToAsync(new FileStream(filePath, FileMode.Create));
                photo.Path_Origional = Path.Combine(folder, uniqueFileName);

                //调整图片大小，并储存到对应的文件夹中
                photo.ResizeImageAndSaveCopies();
                //提交到数据库
                await _photoRepository.CreateOne(photo);
                return View(photo);
            }
            else
            {
                return View();
            }

        }
        //public async Task<IActionResult> AddPhotos(List<Photo> photos)
        //{

        //}
    }
}