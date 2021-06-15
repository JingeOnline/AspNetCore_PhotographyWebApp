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
        public Photo CoverPhoto { get; set; }
        public int? CoverPhotoId { get; set; }

    }
}
