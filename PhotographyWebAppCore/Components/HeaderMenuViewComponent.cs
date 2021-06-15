using Microsoft.AspNetCore.Mvc;
using PhotographyWebAppCore.Models;
using PhotographyWebAppCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Components
{
    public class HeaderMenuViewComponent: ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public HeaderMenuViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<PhotoCategory> categories = await _categoryRepository.GetAll();
            return View(categories);
        }
    }
}
