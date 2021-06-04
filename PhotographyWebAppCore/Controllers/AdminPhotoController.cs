using Microsoft.AspNetCore.Mvc;
using PhotographyWebAppCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotographyWebAppCore.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using PhotographyWebAppCore.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PhotographyWebAppCore.ViewModels;

namespace PhotographyWebAppCore.Controllers
{
    public class AdminPhotoController : Controller
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAlbumRepository _albumRepository;
        public AdminPhotoController(IPhotoRepository photoRepository,
            IWebHostEnvironment webHostEnvironment,
            IAlbumRepository albumRepository)
        {
            _photoRepository = photoRepository;
            _webHostEnvironment = webHostEnvironment;
            _albumRepository = albumRepository;
        }
        public async Task<IActionResult> Index()
        {
            List<Photo> photos = await _photoRepository.GetAll();
            return View(photos);
        }
        [HttpGet]
        public async Task<IActionResult> AddPhotos(int? albumId=null)
        {
            List<Album> albums = await _albumRepository.GetAll();

            Album selectedAlbum=null;
            if (albumId != null)
            {
                selectedAlbum = albums.FirstOrDefault(x=>x.Id==albumId);
            }

            ViewBag.Albums = new SelectList(albums, "Id", "Title", selectedAlbum);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPhotos(PhotoUploadViewModel viewModel)
        {
            List<IFormFile> files = viewModel.Files;
            //int albumId = viewModel.AlbumId;

            if (ModelState.IsValid && files.Count > 0)
            {
                List<Photo> photos = new List<Photo>();
                foreach (IFormFile file in files)
                {
                    Photo photo = new Photo
                    {
                        PhotoFile = file,
                    };
                    if (viewModel.AlbumId != null)
                    {
                        photo.AlbumId = viewModel.AlbumId;
                    }
                    photos.Add(photo);
                    await SavePhoto(photo);
                    photo.ResizeImageAndSaveCopies();
                }
                List<Photo> ps = await _photoRepository.CreateMultiple(photos);
                List<int> ids = ps.Select(x => x.Id).ToList();
                //TempData["UploadedPhotoIds"] = ids;
                return RedirectToAction(nameof(EditAfterUpload), new { ids });
            }
            else
            {
                return View();
            }
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
                await SavePhoto(photo);
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
        [HttpPost]
        public async Task<IActionResult> DeleteOneById(int id)
        {
            //删除本地文件夹内的照片文件
            Photo photo = await _photoRepository.GetById(id);
            string rootFolder = _webHostEnvironment.WebRootPath;
            System.IO.File.Delete(Path.Combine(rootFolder, photo.Path_Origional));
            System.IO.File.Delete(Path.Combine(rootFolder, photo.Path_Big));
            System.IO.File.Delete(Path.Combine(rootFolder, photo.Path_Middle));
            System.IO.File.Delete(Path.Combine(rootFolder, photo.Path_Small));
            //去数据库中删除文件记录
            await _photoRepository.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        //把照片储存到本地文件夹
        private async Task SavePhoto(Photo photo)
        {
            string[] pairs = photo.PhotoFile.FileName.Split('.');
            string extension = pairs[pairs.Length - 1];
            string uniqueFileName = Guid.NewGuid().ToString() + "." + extension;
            string folder = "images\\photos_origional";
            string rootPath = _webHostEnvironment.WebRootPath;
            string filePath = Path.Combine(rootPath, folder, uniqueFileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.PhotoFile.CopyToAsync(stream);
            }
            photo.Path_Origional = Path.Combine(folder, uniqueFileName);
        }

        [HttpGet]
        public async Task<IActionResult> EditAfterUpload(List<int> ids)
        {
            //List<int> ids = TempData["UploadedPhotoIds"];
            List<Photo> allPhotos = await _photoRepository.GetAll();
            List<Photo> photos = allPhotos.Where(x => ids.Contains(x.Id)).ToList();

            List<Album> albums = await _albumRepository.GetAll();
            ViewBag.Albums = new SelectList(albums, "Id", "Title");
            return View(photos);
        }
        [HttpPost]
        public async Task<IActionResult> EditAfterUpload_Post(List<Photo> photos)
        {
            await _photoRepository.UpdateMultiple(photos);

            return RedirectToAction(nameof(Index));
        }
    }
}
