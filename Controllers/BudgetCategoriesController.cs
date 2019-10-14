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
        private readonly ILevel1CategoryRepository _level1CategoryRepository;
        private readonly ILevel2CategoryRepository _level2CategoryRepository;
        private readonly ILevel3CategoryRepository _level3CategoryRepository;
        private readonly IBudgetCategoryRepository _budgetCategoryRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger<BudgetCategoriesController> logger;
        private readonly UserManager<ApplicationUser> userManager;

        public BudgetCategoriesController(ILevel1CategoryRepository level1CategoryRepository,
            ILevel2CategoryRepository level2CategoryRepository,
            ILevel3CategoryRepository level3CategoryRepository, 
            IBudgetCategoryRepository budgetCategoryRepository,
            IHostingEnvironment hostingEnvironment,
            ILogger<BudgetCategoriesController> logger,
            UserManager<ApplicationUser> userManager)
        {
            _level1CategoryRepository = level1CategoryRepository;
            _level2CategoryRepository = level2CategoryRepository;
            _level3CategoryRepository = level3CategoryRepository;
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
            var level1CategoryList = _level1CategoryRepository.GetAllCategory().ToList();
            var level2CategoryList = _level2CategoryRepository.GetAllCategory().ToList();
            var level3CategoryList = _level3CategoryRepository.GetAllCategory().ToList();

            var model = new CreateBudgetCategoryViewModel {
            Level1Categories = level1CategoryList,
            Level2Categories = level2CategoryList,
            Level3Categories = level3CategoryList
            };
                                              

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BudgetCategory model)
        {
            var level1Category = _level1CategoryRepository.GetCategory(model.Level1CategoryId);
            var level2Category = _level2CategoryRepository.GetCategory(model.Level2CategoryId);
            var level3Category = _level3CategoryRepository.GetCategory(model.Level3CategoryId);
            if (ModelState.IsValid)
            {
                BudgetCategory newCategory = new BudgetCategory
                {
                    Name = level1Category.Name + " -> "+ level2Category.Name + " -> "+ level3Category.Name,
                    Level1CategoryId = model.Level1CategoryId,
                    Level2CategoryId = model.Level2CategoryId,
                    Level3CategoryId = model.Level3CategoryId,
                    OwnerId = userManager.GetUserId(HttpContext.User)
                };

                _budgetCategoryRepository.Add(newCategory);
                return RedirectToAction("index","BudgetCategories");
            }

            return View();

        }
    }
}