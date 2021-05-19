using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OriginalPath { get; set; }
        public string BigPath { get; set; }
        public string MiddlePath { get; set; }
        public string SmallPath { get; set; }
        public string Size { get; set; }
        public DateTime CaptureDate { get; set; }
        public DateTime CreateDate { get; set; }
        public PhotoCategory Category { get; set; }
        public Photographer Photographer { get; set; }
    }
}
