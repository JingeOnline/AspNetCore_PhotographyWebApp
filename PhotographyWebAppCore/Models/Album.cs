using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhotographyWebAppCore.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Required,Display(Name ="相册名称")]
        public int Title { get; set; }
        [Required,Display(Name ="相册描述")]
        public string Description { get; set; }
        [Display(Name ="摄影师")]
        public Photographer Photographer { get; set; }
        [Display(Name ="拍摄日期")]
        public DateTime CaptureDate { get; set; }
        [Display(Name ="相册创建时间")]
        public DateTime CreateDate { get; set; }
        [Display(Name ="封面照片")]
        public Photo Cover { get; set; }
        [Display(Name ="相册内所含照片")]
        public List<Photo> Photos { get; set; }
    }
}
