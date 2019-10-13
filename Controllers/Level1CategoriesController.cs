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
    public class Level1CategoriesController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILevel1CategoryRepository _categoryRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;

        public Level1CategoriesController(ILevel1CategoryRepository categoryRepository, IHostingEnvironment hostingEnvironment, ILogger<Level1CategoriesController> logger, UserManager<ApplicationUser> userManager)
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


            Level1Category category = _categoryRepository.GetCategory(id);

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
        public IActionResult Create(Level1Category model)
        {
            if (ModelState.IsValid)
            {
                Level1Category newCategory = new Level1Category
                {
                    Name = model.Name,                    
                    OwnerId = userManager.GetUserId(HttpContext.User)
                };

                _categoryRepository.Add(newCategory);
                return RedirectToAction("details", new { id = newCategory.Id });
            }

            return View();

        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Level1Category category = _categoryRepository.GetCategory(id);
            
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Level1Category model)
        {
            if (ModelState.IsValid)
            {
                Level1Category category = _categoryRepository.GetCategory(model.Id);

                category.Name = model.Name;
                       

                _categoryRepository.Update(category);
                return RedirectToAction("index");
            }

            return View();

        }

    }
}