﻿namespace MyRecipes.Web.ViewModels.SearchRecipes
{
    using System;
    using System.Collections.Generic;

    public class SearchIndexViewModel
    {
        public IEnumerable<IngredientNameIdViewModel> Ingredients { get; set; }
    }
}
