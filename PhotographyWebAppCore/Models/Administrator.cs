using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhotographyWebAppCore.Models
{
    public class Administrator
    {
        [Required(ErrorMessage ="请输入用户名"),Display(Name ="用户名")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="请输入密码"), Display(Name = "密码"),DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="记住密码")]
        public bool RememberMe { get; set; }
    }
}
