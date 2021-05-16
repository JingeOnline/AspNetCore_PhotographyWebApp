using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Controllers
{
    public class PhotoCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
