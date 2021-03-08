using GameFacto.Contract.RequestModel.Product;
using GameFacto.Core.Entities;
using GameFacto.Data.DbContexts;
using GameFacto.Service.IService;
using Microsoft.EntityFrameworkCore;
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

        public int AddProductWithSP(ProductRequestModel model)
        {

          var result= _db.Database.ExecuteSqlCommand("SPProduct @p0, @p1,@p2, @p3,@p4, @p5,@p6, @p7, @p8,@p9", parameters: new[] { $"{model.RecordUserId}", $"{model.UpdateUserId}", $"{model.RecordDate}", $"{model.UpdateDate}", $"{model.Name}", $"{model.Description}", $"{model.Imageurl}", $"{model.Price}", $"{model.CategoryId}", $"{model.IsDeleted}" });

            return result;

            //var Id = _dbContext.AppLogs
            //.FromSqlRaw("SELECT TOP(1) * FROM dbo.[AppLogs] Order by Id desc")
            //.FirstOrDefault();

            //return Id.Id;
        }

    }
}
