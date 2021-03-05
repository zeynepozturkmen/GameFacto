using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public DateTime RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int RecordUserId { get; set; }
        public int UpdateUserId { get; set; }
        public bool IsDeleted { get; set; }
        public string FullName { get; set; }
    }
}
