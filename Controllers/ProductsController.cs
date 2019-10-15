using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;
        private readonly IBudgetCategoryRepository budgetCategoryRepository;

        public ProductsController(IProductRepository productRepository, IHostingEnvironment hostingEnvironment, ILogger<ProductsController> logger, IBudgetCategoryRepository budgetCategoryRepository)
        {
            _productRepository = productRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
            this.budgetCategoryRepository = budgetCategoryRepository;
        }


        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _productRepository.GetAllProduct();
            return View(model);
        }

        [AllowAnonymous]
        public ViewResult Details(string id)
        {
            

            Product product = _productRepository.GetProduct(id);

            if( product == null)
            {
                Response.StatusCode = 404;
                return View("ProductNotFound", id);
            }

            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel()
            {
                Product = product,
                PageTitle = "Product Details"
            };

            return View(productDetailsViewModel);
        }

        [HttpGet]        
        public ViewResult Create()
        {
            var budgetCategoryList = budgetCategoryRepository.GetAllBudgetCategory().ToList();
            var model = new ProductCreateViewModel
            {
                BudgetCategories = budgetCategoryList
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Product newProduct = new Product
                {
                    Name = model.Name,
                    Qty = model.Qty,
                    EAN = model.EAN,
                    Unit = model.Unit,
                    BudgetCategoryId = model.BudgetCategoryId,                    
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
            var budgetCategoryList = budgetCategoryRepository.GetAllBudgetCategory().ToList();

            Product product = _productRepository.GetProduct(id);
            ProductEditViewModel productEditViewModel = new ProductEditViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Qty = product.Qty,
                Unit = product.Unit,
                EAN = product.EAN,
                BudgetCategories = budgetCategoryList,
                BudgetCategoryId = product.BudgetCategoryId,
                ExistingPhotoPath = product.PhotoPath,
                
                };

            //if (product.BudgetCategoryId == null) { productEditViewModel.BudgetCategoryId = 2; }
            //else { productEditViewModel.BudgetCategoryId = product.BudgetCategoryId; } ;

            
            return View(productEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = _productRepository.GetProduct(model.Id);

                product.Name = model.Name;
                product.Qty = model.Qty;
                product.Unit = model.Unit;
                product.EAN = model.EAN;
                product.BudgetCategoryId = model.BudgetCategoryId;

                if(model.Photo != null)

                { 
                    if(model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    product.PhotoPath = ProcessUploadedFile(model);
                }
                
                _productRepository.Update(product);
                return RedirectToAction("index");
            }

            return View();

        }

        private string ProcessUploadedFile(ProductCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
                
            }

            return uniqueFileName;
        }
    }
}