using GameFacto.Contract.ResponseModel.Category;
using GameFacto.Core.Entities;
using GameFacto.Data.DbContexts;
using GameFacto.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameFacto.Service.Service
{
    public class CategoryService : BaseService<Category>, ICagetoryService
    {
        public CategoryService(GameFactoDbContext db):base(db)
        {

        }

     
    }
}
