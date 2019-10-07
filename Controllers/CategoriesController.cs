using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;

        public CategoriesController(ICategoryRepository categoryRepository, IHostingEnvironment hostingEnvironment, ILogger<CategoriesController> logger, UserManager<ApplicationUser> userManager)
        {
            _categoryRepository = categoryRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
            this.userManager = userManager;
        }


        public ViewResult Index()
        {
            var model = _categoryRepository.GetAllCategory();
            return View(model);
        }

        public ViewResult Details(int id)
        {


            Category category = _categoryRepository.GetCategory(id);

            if (category == null)
            {
                Response.StatusCode = 404;
                return View("CategoryNotFound", id);
            }

            

            return View(category);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category
                {
                    Name = model.Name,
                    CategoryLevel = model.CategoryLevel,
                    OwnerId = userManager.GetUserId(HttpContext.User)
                };

                _categoryRepository.Add(newCategory);
                return RedirectToAction("details", new { id = newCategory.Id });
            }

            return View();

        }

    }
}