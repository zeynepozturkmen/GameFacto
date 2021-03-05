using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Contract.RequestModel.Category
{
    public class CategoryRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }

    }
}
