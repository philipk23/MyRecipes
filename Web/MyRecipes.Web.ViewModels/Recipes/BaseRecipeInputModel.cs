 namespace MyRecipes.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseRecipeInputModel
    {
        [MinLength(4)]
        [Required]
        public string Name { get; set; }

        [MinLength(100)]
        [Required]
        public string Instructions { get; set; }

        [Range(1, 100)]
        public int PortionsCount { get; set; }

        [Range(0, 24 * 60)]
        [Display(Name = "Prep time (in minutes)")]
        public int PreparationTime { get; set; }

        [Range(0, 24 * 60)]
        [Display(Name = "Cooking time (in minutes)")]
        public int CookingTime { get; set; }

        [Display(Name = "Categories")]
        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
