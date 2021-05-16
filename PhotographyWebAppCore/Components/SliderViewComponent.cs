using Microsoft.AspNetCore.Mvc;
using PhotographyWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Controllers
{
    public class SliderViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //滑动幻灯片对象列表
            List<SlideModel> slides = new List<SlideModel>
            {
                new SlideModel{ImagePath="images/slides/s001.jpg",Title="花魁斗艳",Description="Nulla vitae elit libero, a pharetra augue mollis interdum." },
                new SlideModel{ImagePath="images/slides/s002.jpg",Title="洛可可婚纱写真",Description="Nulla vitae elit libero, a pharetra augue mollis interdum." },
                new SlideModel{ImagePath="images/slides/s003.jpg",Title="D大调梦想",Description="Nulla vitae elit libero, a pharetra augue mollis interdum." },
                new SlideModel{ImagePath="images/slides/s004.jpg",Title="光影生活",Description="Nulla vitae elit libero, a pharetra augue mollis interdum." },
            };
            return View(slides);
        }
    }
}
