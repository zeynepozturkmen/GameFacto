using GameFacto.Contract.RequestModel.Category;
using GameFacto.Contract.ResponseModel.Category;
using GameFacto.Core.Entities;
using GameFacto.Data.DbContexts;
using GameFacto.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFacto.Service.Service
{
    public class CategoryService : BaseService<Category>, ICagetoryService
    {
        public CategoryService(GameFactoDbContext db) : base(db)
        {

        }

        public async Task<Category> AddCategory(CategoryRequestModel model)
        {
            var newCategory = new Category();
            newCategory.Name = model.Name;
            newCategory.Description = model.Description;

            if (model.ParentId == 0)
            {

                newCategory.ParentId = null;
            }
            else
            {
                newCategory.ParentId = model.ParentId;
            }

            newCategory.RecordUserId = 1;
            newCategory.RecordDate = DateTime.Now;


            await _db.Category.AddAsync(newCategory);

            await _db.SaveChangesAsync();

            return newCategory;
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            var list = await _db.Category.Where(x => !x.IsDeleted).Include(x => x.ParentCategory).ToListAsync();

            return list;
        }

    }
}
