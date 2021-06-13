using Microsoft.AspNetCore.Http;
using PhotographyWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.ViewModels
{
    public class PhotoUploadViewModel
    {
        public int? AlbumId { get; set; }
        public int? PhotographerId { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
