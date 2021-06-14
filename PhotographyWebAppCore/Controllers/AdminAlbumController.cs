using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhotographyWebAppCore.Models;
using PhotographyWebAppCore.Repositories;
using PhotographyWebAppCore.ViewModels;
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
        public AdminAlbumController(IAlbumRepository albumRepository, ICategoryRepository categoryRepository)
        {
            _albumRepository = albumRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string categoryId = null)
        {
            List<Album> albums = await _albumRepository.GetAll();
            ViewBag.AllAlbumCount = (albums == null) ? 0 : albums.Count();
            //按照类型分组
            List<AlbumViewCategoryViewModel> categoryViewModelList = new List<AlbumViewCategoryViewModel>();
            var categoryGroups = albums.GroupBy(x => x.CategoryId).OrderBy(x => x.Key);
            foreach (var group in categoryGroups)
            {
                if (group.Key == null)
                {
                    categoryViewModelList.Add(new AlbumViewCategoryViewModel
                    {
                        CategoryId = "null",
                        CategoryName = "未指定",
                        AlbumCount = group.Count(),
                    });
                }
                else
                {
                    PhotoCategory category = await _categoryRepository.GetById((int)group.Key);
                    categoryViewModelList.Add(new AlbumViewCategoryViewModel
                    {
                        CategoryId = group.Key.ToString(),
                        CategoryName = category.Name,
                        AlbumCount = group.Count(),
                    });
                }
            }
            ViewBag.CategoryViewModel = categoryViewModelList;
            //接收传入的参数【类型】
            if (categoryId != null)
            {
                if (categoryId == "null")
                {
                    albums = albums.Where(x => x.CategoryId == null).ToList();
                }
                else
                {
                    int id = Int32.Parse(categoryId);
                    albums = albums.Where(x => x.CategoryId == id).ToList();
                }
            }

            return View(albums);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOne(string albumName = null, bool isSuccess = false, int? albumId = null)
        {
            //ViewBag.IsSuccess = isSuccess;
            List<PhotoCategory> categories = await _categoryRepository.GetAll();
            //下拉选择菜单
            //第一个参数是要传入的列表，第二个参数是作为value提交的字段，第三个参数是作为text显示的字段。
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.AlbumName = albumName;
            ViewBag.AlbumId = albumId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOne(Album album)
        {
            if (ModelState.IsValid)
            {
                Album a = await _albumRepository.CreateOne(album);
                return RedirectToAction(nameof(CreateOne), new { isSuccess = true, albumName = a.Title, albumId = a.Id });
            }
            else
            {
                List<PhotoCategory> categories = await _categoryRepository.GetAll();
                ViewBag.Categories = new SelectList(categories, "Id", "Name");
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _albumRepository.DeleteById_LeavePhotos(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteByIdAndPhotos(int id)
        {
            await _albumRepository.DeleteById_DeletePhotos(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Album album = await _albumRepository.GetById(id);
            PhotoCategory category = album.Category;
            List<PhotoCategory> categories = await _categoryRepository.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", category);
            return View(album);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Album album)
        {
            await _albumRepository.UpdateOne(album);
            return RedirectToAction(nameof(Index));
        }
    }
}
