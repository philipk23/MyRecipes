namespace MyRecipes.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using Xunit;

    public class VotesServiceTests
    {
        [Fact]
        public async Task WhenUserVotesTwiceOnlyOneVoteShouldBeCounted()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();

            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>()))
                .Callback((Vote vote) => list.Add(vote));

            var service = new VotesService(mockRepo.Object);

            await service.SetVoteAsync("1", 1, 1);
            await service.SetVoteAsync("1", 1, 5);
            await service.SetVoteAsync("1", 1, 5);
            await service.SetVoteAsync("1", 1, 5);
            await service.SetVoteAsync("1", 1, 5);

            Assert.Single(list);
            Assert.Equal(5, list.First().Value);
        }

        [Fact]
        public async Task WhenTwoUsersVoteForTheSameRecipeTheAverageVoteShouldBeCorrect()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();

            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>()))
                .Callback((Vote vote) => list.Add(vote));

            var service = new VotesService(mockRepo.Object);

            await service.SetVoteAsync("Filip", 1, 2);
            await service.SetVoteAsync("Sasho", 1, 5);
            await service.SetVoteAsync("Filip", 1, 4);

            mockRepo.Verify(x => x.AddAsync(It.IsAny<Vote>()), Times.Exactly(2));

            Assert.Equal(2, list.Count);
            Assert.Equal(4.5, service.GetAverageVotes(1));
        }
    }
}
