using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WebApiDemo01.Models;
using WebApiDemo01.Services;
using WebLayer.Models;

namespace WebLayer.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string url = "https://localhost:7015/api/Product";

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
            _httpClient = new HttpClient();

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            using (HttpResponseMessage response = await _httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<List<Product>>(content);
                    var model = new HomeViewModel { Products = products };
                    return View(model);

                }
                else
                {
                    Console.WriteLine($"Errore nella richiesta: {response.StatusCode}");

                    return View();

                }
            }
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateProductViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel product)
        {
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await _httpClient.PostAsync(url, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Console.WriteLine($"Errore nella richiesta: {response.StatusCode}");
                    return View();
                }
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var getProductUrl = $"{url}/{id}";

            using (HttpResponseMessage getProductResponse = await _httpClient.GetAsync(getProductUrl))
            {
                if (getProductResponse.IsSuccessStatusCode)
                {
                    var currentProductJson = await getProductResponse.Content.ReadAsStringAsync();
                    var currentProduct = JsonConvert.DeserializeObject<CreateProductViewModel>(currentProductJson);
                    var model = new EditProductViewModel()
                    {   Id = id,
                        ProductName = currentProduct.ProductName,
                        ProductDescription = currentProduct.ProductDescription,
                        ProductCategory = currentProduct.ProductCategory,
                        ProductPrice = currentProduct.ProductPrice,
                        ProductStock = currentProduct.ProductStock,

                    };
                    return View(model);
                }
                else
                {
                    Console.WriteLine($"Errore nella richiesta: {getProductResponse.StatusCode}");
                    return View();
                }
            }
        }
       
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var deleteProductUrl = $"{url}/{id}";

            using (HttpResponseMessage response = await _httpClient.DeleteAsync(deleteProductUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Console.WriteLine($"Errore nella richiesta: {response.StatusCode}");
                    return NotFound();
                }
            }
        }


    }
}