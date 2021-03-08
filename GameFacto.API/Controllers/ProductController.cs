using GameFacto.Contract.RequestModel.Product;
using GameFacto.Service.IService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace GameFacto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;     
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct([FromForm][Required] ProductRequestModel model)
        {

            Guid g = Guid.NewGuid();
            var fileName = g.ToString() + model.Image.FileName;

            var filesPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Files");

            var contentPath = _webHostEnvironment.ContentRootPath;

            contentPath= contentPath.Replace("GameFacto.API", "GameFacto.UI\\wwwroot\\");

            var filePath = Path.Combine(contentPath, "UploadFiles", fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.Image.CopyTo(stream);
            }


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.Image.CopyTo(stream);
            }

            model.Imageurl = fileName;
            //model.RecordUserId = 1;
            //model.RecordDate = DateTime.Now;

            var result= _productService.AddProductWithSP(model);

            if (result>0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
         
        }

        [HttpGet]
        [Route("get/all")]
        public async Task<IActionResult> ProductGetAll()
        {
            var list = await _productService.GetAllAsync();
            
            return Ok(list);
        }
    }
}
