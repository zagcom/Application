using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Application.Controllers
{
    public class BudgetCategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBudgetCategoryRepository _budgetCategoryRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger<BudgetCategoriesController> logger;
        private readonly UserManager<ApplicationUser> userManager;

        public BudgetCategoriesController(ICategoryRepository categoryRepository, IBudgetCategoryRepository budgetCategoryRepository, IHostingEnvironment hostingEnvironment, ILogger<BudgetCategoriesController> logger, UserManager<ApplicationUser> userManager)
        {
            _categoryRepository = categoryRepository;
            _budgetCategoryRepository = budgetCategoryRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
            this.userManager = userManager;
        }

        

        public IActionResult Index()
        {
            var model = _budgetCategoryRepository.GetAllBudgetCategory();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new CreateBudgetCategoryViewModel();


            var model = _categoryRepository.GetAllCategory();
           
            
            foreach (var item in model)
            {
                if (item.CategoryLevel.Equals(0)){
                    vm.CategoryLevel1List.Add(item);
                }
                if (item.CategoryLevel.Equals(1))
                {
                    vm.CategoryLevel2List.Add(item);
                }
                if (item.CategoryLevel.Equals(2))
                {
                    vm.CategoryLevel3List.Add(item);
                }
            }

            

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(BudgetCategory model)
        {
            if (ModelState.IsValid)
            {
                BudgetCategory newCategory = new BudgetCategory
                {
                    Name = model.Name,
                    CategoryLevel1 = model.CategoryLevel1,
                    CategoryLevel2 = model.CategoryLevel2,
                    CategoryLevel3 = model.CategoryLevel3,
                    OwnerId = userManager.GetUserId(HttpContext.User)
                };

                _budgetCategoryRepository.Add(newCategory);
                return RedirectToAction("details", new { id = newCategory.Id });
            }

            return View();

        }
    }
}