using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProductsController(IProductRepository productRepository, IHostingEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index()
        {
            var model = _productRepository.GetAllProduct();
            return View(model);
        }


        public ViewResult Details(string id)
        {
            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel()
            {
                Product = _productRepository.GetProduct(id),
                PageTitle = "Product Details"
            };

            return View(productDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Product newProduct = new Product
                {
                    Name = model.Name,
                    Qty = model.Qty,
                    EAN = model.EAN,
                    Unit = model.Unit,
                    PhotoPath = uniqueFileName
                };

                _productRepository.Add(newProduct);
                return RedirectToAction("details", new { id = newProduct.Id });
            }

            return View();

        }

        [HttpGet]
        public ViewResult Edit(string id)
        {
            Product product = _productRepository.GetProduct(id);
            ProductEditViewModel productEditViewModel = new ProductEditViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Qty = product.Qty,
                Unit = product.Unit,
                EAN = product.EAN,
                ExistingPhotoPath = product.PhotoPath
            };
            return View(productEditViewModel);
        }
    }
}