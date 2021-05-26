using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotographyWebAppCore.Models
{
    public class Photographer
    {
        [Key]
        public int Id { get; set; }

        [Required,Display(Name="姓名")]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required,Display(Name="简介")]
        [MaxLength(1024)]
        public string Description { get; set; }

        [Display(Name="头像")]
        public Photo Avatar { get; set; }
        [ForeignKey("Avatar")]
        public int? AvatarId { get; set; }
        
        //当两个类型之间定义了多个导航属性，必须手动配置
        [InverseProperty("Photographer")]
        [Display(Name ="关联的所有照片")]
        public List<Photo> Photos { get; set; }
    }
}
