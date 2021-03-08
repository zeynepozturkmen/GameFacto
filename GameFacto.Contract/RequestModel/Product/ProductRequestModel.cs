using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Contract.RequestModel.Product
{
    public class ProductRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imageurl { get; set; }
        public IFormFile Image { get; set; }

        public float Price { get; set; }
        public int CategoryId { get; set; }
        public int RecordUserId { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
