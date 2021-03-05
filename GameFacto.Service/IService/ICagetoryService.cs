using GameFacto.Contract.RequestModel.Category;
using GameFacto.Contract.ResponseModel.Category;
using GameFacto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameFacto.Service.IService
{
    public interface ICagetoryService : IBaseService<Category>
    {
        Task<List<Category>> GetAllCategoryAsync();
        Task<Category> AddCategory(CategoryRequestModel model);
    }
}
