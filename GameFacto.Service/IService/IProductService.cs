using GameFacto.Contract.RequestModel.Product;
using GameFacto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFacto.Service.IService
{
    public interface IProductService : IBaseService<Product>
    {
        int AddProductWithSP(ProductRequestModel model);

    }
}
