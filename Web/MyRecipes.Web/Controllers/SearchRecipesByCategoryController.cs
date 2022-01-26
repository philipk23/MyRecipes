namespace MyRecipes.Web.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels.Recipes;
    using MyRecipes.Web.ViewModels.SearchRecipesByCategory;

    public class SearchRecipesByCategoryController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public SearchRecipesByCategoryController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchIndexViewModel
            {
                Categories = this.categoriesService.GetAllCategories<CategoriesByIdAndNameViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult List(int categoryId)
        {
            var viewModel = new SearchByCategoryViewModel
            {
                FoundRecipes = this.categoriesService.SearchRescipesByCategory<RecipeInListViewModel>(categoryId),
            };

            return this.View(viewModel);
        }
    }
}
