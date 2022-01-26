namespace MyRecipes.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;
    using MyRecipes.Web.ViewModels.Recipes;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;

        public CategoriesService(
            IDeletableEntityRepository<Category> categoryRepository,
            IDeletableEntityRepository<Recipe> recipeRepository)
        {
            this.categoryRepository = categoryRepository;
            this.recipeRepository = recipeRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.categoryRepository
                .AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .ToList()
                .OrderBy(x => x.Name)
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<T> GetAllCategories<T>()
        {
            return this.categoryRepository.AllAsNoTracking().OrderBy(x => x.Name).To<T>().ToList();
        }

        public IEnumerable<T> SearchRescipesByCategory<T>(int id)
        {
            return this.recipeRepository.AllAsNoTracking().Where(x => x.CategoryId == id).To<T>().ToList();
        }
    }
}
