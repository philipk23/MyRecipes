namespace MyRecipes.Web.ViewModels.SearchRecipesByCategory
{
    using System;
    using System.Collections.Generic;

    using MyRecipes.Web.ViewModels.Recipes;

    public class SearchByCategoryViewModel
    {
        public IEnumerable<RecipeInListViewModel> FoundRecipes { get; set; }
    }
}
