using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
    }
}
