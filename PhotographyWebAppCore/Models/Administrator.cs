using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhotographyWebAppCore.Controllers
{
    public class Administrator
    {
        [Required,Display(Name ="用户名")]
        public string UserName { get; set; }
        [Required, Display(Name = "密码"),DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="记住密码")]
        public bool RememberMe { get; set; }
    }
}
