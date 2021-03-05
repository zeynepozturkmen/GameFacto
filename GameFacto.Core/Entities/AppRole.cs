using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Core.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public string RoleDescription { get; set; }
    }
}
