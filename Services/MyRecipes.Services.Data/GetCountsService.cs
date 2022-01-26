namespace MyRecipes.Services.Data
{
    using System;
    using System.Linq;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Data.DTOs;
    using MyRecipes.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IRepository<Image> imageRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;

        public GetCountsService(
            IDeletableEntityRepository<Category> categoriesRepository,
            IRepository<Image> imageRepository,
            IDeletableEntityRepository<Ingredient> ingredientRepository,
            IDeletableEntityRepository<Recipe> recipeRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.imageRepository = imageRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipeRepository = recipeRepository;
        }

        public CountsDto GetCounts()
        {
            var viewModel = new CountsDto
            {
                RecipesCount = this.recipeRepository.All().Count(),
                CategoriesCount = this.categoriesRepository.All().Count(),
                ImagesCount = this.imageRepository.All().Count(),
                IngredientsCount = this.ingredientRepository.All().Count(),
            };

            return viewModel;
        }
    }
}
