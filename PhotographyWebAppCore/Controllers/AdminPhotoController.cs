using Microsoft.AspNetCore.Mvc;
using PhotographyWebAppCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotographyWebAppCore.Models;

namespace PhotographyWebAppCore.Controllers
{
    public class AdminPhotoController : Controller
    {
        private readonly IPhotoRepository _photoRepository;
        public AdminPhotoController(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        public async Task<IActionResult> Photo()
        {
            List<Photo> photos = await _photoRepository.GetAll();
            return View(photos);
        }
        public IActionResult AddPhoto()
        {
            return View();
        }
    }
}
