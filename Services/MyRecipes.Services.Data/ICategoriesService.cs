namespace MyRecipes.Services.Data
{
    using System;
    using System.Collections.Generic;

    using MyRecipes.Web.ViewModels.Recipes;

    public interface ICategoriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        IEnumerable<T> SearchRescipesByCategory<T>(int id);

        IEnumerable<T> GetAllCategories<T>();
    }
}
