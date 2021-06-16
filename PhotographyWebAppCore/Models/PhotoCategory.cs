using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotographyWebAppCore.Models
{
    public class PhotoCategory
    {
        [Key]
        public int Id { get; set; }
        [Required,Display(Name ="类名"),MaxLength(64)]
        public string Name { get; set; }
        [Required,Display(Name="类型描述"),MaxLength(length:1024)]
        public string Description { get; set; }
        [InverseProperty("Category")]
        [Display(Name ="包含相册")]
        public List<Album> Albums { get; set; }

        [ForeignKey(nameof(CoverPhotoId))]
        [Display(Name="封面图片")]
        public Photo CoverPhoto { get; set; }
        [Display(Name = "封面图片")]
        public int? CoverPhotoId { get; set; }

        [ForeignKey(nameof(BackgroundImageId))]
        [Display(Name ="背景图片")]
        public Photo BackgroundImage { get; set; }
        [Display(Name = "背景图片")]
        public int? BackgroundImageId { get; set; }
    }
}
