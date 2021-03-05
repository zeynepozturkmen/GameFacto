using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameFacto.Contract.RequestModel
{
    public class LoginRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool Persistent { get; set; }
        public bool Lock { get; set; }

    }
}
