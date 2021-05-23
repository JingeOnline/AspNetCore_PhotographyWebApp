using Microsoft.AspNetCore.Http;
using PhotographyWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.ViewModels
{
    public class PhotoViewModel
    {
        public Photo Photo { get; set; }
        public IFormFile File { get; set; }
    }
}
