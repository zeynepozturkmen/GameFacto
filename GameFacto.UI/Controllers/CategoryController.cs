using GameFacto.Contract.RequestModel.Category;
using GameFacto.Core.Entities;
using GameFacto.Service.IService;
using GameFacto.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameFacto.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICagetoryService _categoryService;
        public CategoryController(ICagetoryService cagetoryService)
        {
            _categoryService = cagetoryService;
        }
        public async Task<IActionResult> Index()
        {
            var list =await _categoryService.GetAllCategoryAsync();


            return View(list);
        }

        public async Task<IActionResult> AddCategory()
        {
            var list =await _categoryService.GetAllAsync();
            //ViewBag.ParentCategoryList = _categoryService.GetAllAsync();
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryRequestModel model)
        {
            if (model is null)
            {
                return Json(new { failed = true, message = "Model boş." });
            }


            var category = new Category()
            {
                Name = model.Name,
                Description = model.Description,
                ParentId = model.ParentId
            };

            var newCategory =await _categoryService.AddCategory(model);

            if (newCategory != null)
            {
                return Json(new { failed = false, message = "Kategori oluştu." });
            }
            else
            {
                return Json(new { failed = true, message = "Hata oluştu." });
            }
        }

    }
}
