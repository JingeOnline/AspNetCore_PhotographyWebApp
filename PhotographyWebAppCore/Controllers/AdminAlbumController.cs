using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhotographyWebAppCore.Models;
using PhotographyWebAppCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Controllers
{
    public class AdminAlbumController : Controller
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly ICategoryRepository _categoryRepository;
        public AdminAlbumController(IAlbumRepository albumRepository,ICategoryRepository categoryRepository)
        {
            _albumRepository = albumRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Album> albums = await _albumRepository.GetAll();
            return View(albums);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOne()
        {
            //ViewBag.IsSuccess = isSuccess;
            List<PhotoCategory> categories = await _categoryRepository.GetAll();
            //下拉选择菜单
            //第一个参数是要传入的列表，第二个参数是作为value提交的字段，第三个参数是作为text显示的字段。
            ViewBag.Categories = new SelectList(categories,"Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOne(Album album)
        {
            if (ModelState.IsValid)
            {
                Album a = await _albumRepository.CreateOne(album);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
