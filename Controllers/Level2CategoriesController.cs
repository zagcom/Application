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
    public class Level2CategoriesController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILevel2CategoryRepository _categoryRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;

        public Level2CategoriesController(ILevel2CategoryRepository categoryRepository, IHostingEnvironment hostingEnvironment, ILogger<Level2CategoriesController> logger, UserManager<ApplicationUser> userManager)
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


            Level2Category category = _categoryRepository.GetCategory(id);

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
        public IActionResult Create(Level2Category model)
        {
            if (ModelState.IsValid)
            {
                Level2Category newCategory = new Level2Category
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
            Level2Category category = _categoryRepository.GetCategory(id);
            
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Level2Category model)
        {
            if (ModelState.IsValid)
            {
                Level2Category category = _categoryRepository.GetCategory(model.Id);

                category.Name = model.Name;
                       

                _categoryRepository.Update(category);
                return RedirectToAction("index");
            }

            return View();

        }

    }
}