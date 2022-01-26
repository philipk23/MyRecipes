namespace MyRecipes.Web.ViewModels.SearchRecipesByCategory
{
    using System;
    using System.Collections.Generic;

    public class SearchIndexViewModel
    {
        public int CategoryId { get; set; }

        public IEnumerable<CategoriesByIdAndNameViewModel> Categories { get; set; }
    }
}
