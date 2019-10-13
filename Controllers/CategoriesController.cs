using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ILevel1CategoryRepository level1CategoryRepository;
        private readonly ILevel2CategoryRepository level2CategoryRepository;
        private readonly ILevel3CategoryRepository level3CategoryRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger<CategoriesController> logger;

        public CategoriesController(ILevel1CategoryRepository level1CategoryRepository, ILevel2CategoryRepository level2CategoryRepository, ILevel3CategoryRepository level3CategoryRepository, IHostingEnvironment hostingEnvironment, ILogger<CategoriesController> logger)
        {
            this.level1CategoryRepository = level1CategoryRepository;
            this.level2CategoryRepository = level2CategoryRepository;
            this.level3CategoryRepository = level3CategoryRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            var level1CategoryModel = level1CategoryRepository.GetAllCategory();
            var level2CategoryModel = level2CategoryRepository.GetAllCategory();
            var level3CategoryModel = level3CategoryRepository.GetAllCategory();

            AllLevelCategoryViewModel model = new AllLevelCategoryViewModel()
            {
                Level1Category = level1CategoryModel,
                Level2Category = level2CategoryModel,
                Level3Category = level3CategoryModel
            };
            return View(model);
        }
    }
}