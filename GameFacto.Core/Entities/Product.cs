using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Imageurl { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
