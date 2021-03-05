using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Contract.RequestModel
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string FullName { get; set; }
    }
}
