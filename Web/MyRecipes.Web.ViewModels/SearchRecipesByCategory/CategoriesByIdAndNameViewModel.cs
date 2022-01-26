namespace MyRecipes.Web.ViewModels.SearchRecipesByCategory
{
    using System;

    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;

    public class CategoriesByIdAndNameViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
