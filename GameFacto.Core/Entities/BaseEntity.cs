using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int RecordUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
