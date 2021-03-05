using GameFacto.Core.Entities;
using GameFacto.Data.DbContexts;
using GameFacto.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Service.Service
{
    public class ProductService : BaseService<Product>,IProductService
    {
        public ProductService(GameFactoDbContext db):base(db)
        {

        }



    }
}
