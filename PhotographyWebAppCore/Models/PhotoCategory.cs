using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhotographyWebAppCore.Models
{
    public class PhotoCategory
    {
        public int Id { get; set; }
        [Required,Display(Name ="类名")]
        public string Name { get; set; }
        [Required,Display(Name="类型描述")]
        public string Description { get; set; }
    }
}
