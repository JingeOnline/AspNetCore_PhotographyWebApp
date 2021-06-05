using Microsoft.AspNetCore.Mvc;
using PhotographyWebAppCore.Models;
using PhotographyWebAppCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Controllers
{
    public class AdminPhotographer : Controller
    {
        private readonly IPhotographerRepository _photographerRepository;
        private readonly IPhotoRepository _photoRepository;
        public AdminPhotographer(IPhotographerRepository photographerRepository,IPhotoRepository photoRepository)
        {
            _photographerRepository = photographerRepository;
            _photoRepository = photoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Photographer> photographers = await _photographerRepository.GetAll();
            return View(photographers);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOne(bool isSuccess = false)
        {
            List<Photo> photos = await _photoRepository.GetAll();
            photos = photos.Where(x => x.AlbumId == null).ToList();
            ViewBag.IsSuccess = isSuccess;
            ViewBag.Photos = photos;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOne(Photographer photographer)
        {
            if (ModelState.IsValid)
            {
                Photographer p = await _photographerRepository.CreateOne(photographer);
                return RedirectToAction(nameof(CreateOne), new { isSuccess = true });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateById(int id)
        {
            List<Photo> photos = await _photoRepository.GetAll();
            photos = photos.Where(x => x.AlbumId == null).ToList();
            ViewBag.Photos = photos;
            Photographer photographer = await _photographerRepository.GetById(id);
            return View(photographer);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateById(Photographer photographer)
        {
            if (ModelState.IsValid)
            {
                Photographer p = await _photographerRepository.Update(photographer);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _photographerRepository.DelteById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
