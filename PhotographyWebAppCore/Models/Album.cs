using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotographyWebAppCore.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "相册名称")]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required, Display(Name = "相册描述")]
        [MaxLength(1024)]
        public string Description { get; set; }

        [Display(Name = "相册更新时间")]
        public DateTime LastUpdate { get; set; }

        [Display(Name = "相册创建时间")]
        public DateTime CreatedDateTime { get; set; }

        [Display(Name = "封面照片")]
        //这里如果不设置外键特征值，则并不会知道该属性是个导航属性。
        //想反，会生成一个影子属性字段，在数据库中生成两列CoverPhotoId字段。
        [ForeignKey("CoverPhotoId")]
        public Photo CoverPhoto { get; set; }
        [Display(Name = "封面照片")]
        public int? CoverPhotoId { get; set; }

        [InverseProperty("Album")]
        [Display(Name = "所含照片")]
        public List<Photo> Photos { get; set; }

        [Display(Name = "相册类型")]
        public PhotoCategory Category { get; set; }
        [Display(Name = "相册类型")]
        public int? CategoryId { get; set; }
    }
}
