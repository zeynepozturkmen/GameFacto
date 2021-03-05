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
        public IActionResult Index()
        {
            var list = _categoryService.GetAllAsync();

            return View(list);
        }
    }
}
