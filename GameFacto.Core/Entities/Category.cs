using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual List<Category> Subcategories { get; set; }
        public virtual List<Product> ProductList { get; set; } = new List<Product>();
    }
}
