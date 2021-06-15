using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PhotographyWebAppCore.Models;
using PhotographyWebAppCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Controllers
{
    public class SliderViewComponent : ViewComponent
    {

        private AppConfig _appConfig;
        private readonly IAlbumRepository _albumRepository;

        public SliderViewComponent(IOptionsMonitor<AppConfig> appConfig, IAlbumRepository albumRepository)
        {
            //读取appsetting.json文件中的配置信息，并当数据修改后允许热重载
            _appConfig = appConfig.CurrentValue;
            appConfig.OnChange(config=>
            {
                _appConfig = config;
            });


            _albumRepository = albumRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //读取appsettings中储存的幻灯片相册id
            List<int> sliderAlbumIds = _appConfig.SliderAlbumIds;
            List<Album> albums = await _albumRepository.GetAll();
            //如果没有设置，返回所有相册。如果设置了，则返回指定的相册。
            if (sliderAlbumIds != null)
            {
                albums = albums.Where(x => sliderAlbumIds.Contains(x.Id)).ToList();
            }
            return View(albums);
        }
    }
}
