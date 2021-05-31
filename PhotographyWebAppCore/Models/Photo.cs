using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace PhotographyWebAppCore.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        [Display(Name ="照片名称")]
        public string Title { get; set; }
        
        [MaxLength(1024)]
        [Display(Name ="照片描述")]
        public string Description { get; set; }

        public string Path_Origional { get; set; }
        public string Path_Big { get; set; }
        public string Path_Middle { get; set; }
        public string Path_Small { get; set; }

        public DateTime? CaptureDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public DateTime UploadDateTime { get; set; }

        [Display(Name ="摄影师")]
        public Photographer Photographer { get; set; }
        public int? PhotographerId { get; set; }

        [NotMapped]
        [Required]
        [Display(Name ="图片文件")]
        public IFormFile PhotoFile { get; set; }
    }
}
