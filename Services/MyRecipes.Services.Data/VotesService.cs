namespace MyRecipes.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVotes(int recipeId)
        {
            return this.votesRepository.All().Where(x => x.RecipeId == recipeId).Average(x => x.Value);
        }

        public async Task SetVoteAsync(string userId, int recipeId, byte value)
        {
            var vote = this.votesRepository.All().FirstOrDefault(x => x.RecipeId == recipeId && x.UserId == userId);

            if (vote == null)
            {
                vote = new Vote
                {
                    UserId = userId,
                    RecipeId = recipeId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}
