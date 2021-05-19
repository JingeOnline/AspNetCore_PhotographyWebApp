using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhotographyWebAppCore.Models
{
    public class Photographer
    {
        public int Id { get; set; }
        [Required,Display(Name="姓名")]
        public string Name { get; set; }
        [Required,Display(Name="简介")]
        public string Description { get; set; }
        [Display(Name="头像")]
        public Photo Avatar { get; set; }
    }
}
