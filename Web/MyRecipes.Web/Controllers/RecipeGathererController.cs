namespace MyRecipes.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Services;

    public class RecipeGathererController : BaseController
    {
        private readonly IGotvachBgScraperService gotvachBgScraperService;

        public RecipeGathererController(IGotvachBgScraperService gotvachBgScraperSevice)
        {
            this.gotvachBgScraperService = gotvachBgScraperSevice;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Add()
        {
            await this.gotvachBgScraperService.ImportRecipesAsync();

            return this.Redirect("/");
        }
    }
}
