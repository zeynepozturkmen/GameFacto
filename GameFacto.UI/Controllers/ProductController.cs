using GameFacto.Core.Entities;
using GameFacto.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GameFacto.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public  IActionResult Index()
        {          
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56022/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;
                response = client.GetAsync("api/product/get/all").Result;
                if (response.IsSuccessStatusCode)
                {
                    var productList = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;


                    return View(productList);

                }

            }
            return View(new List<Product>());
        }

    }
}
