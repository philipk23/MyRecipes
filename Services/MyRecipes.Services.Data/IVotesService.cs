namespace MyRecipes.Services.Data
{
    using System;
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task SetVoteAsync(string userId, int recipeId, byte value);

        double GetAverageVotes(int recipeId);
    }
}
