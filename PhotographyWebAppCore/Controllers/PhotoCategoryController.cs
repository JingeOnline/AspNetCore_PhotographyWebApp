using Microsoft.AspNetCore.Mvc;
using PhotographyWebAppCore.Models;
using PhotographyWebAppCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Controllers
{
    public class PhotoCategoryController : Controller
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PhotoCategoryController(IAlbumRepository albumRepository,ICategoryRepository categoryRepository)
        {
            _albumRepository = albumRepository;
            _categoryRepository = categoryRepository;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> Index(int categoryId)
        {
            PhotoCategory category = await _categoryRepository.GetById(categoryId);
            ViewBag.Category = category;

            List<Album> albums = await _albumRepository.GetAll();
            albums = albums.Where(x => x.CategoryId == categoryId).ToList();
            return View(albums);
        }
    }
}
