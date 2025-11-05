using Xunit;
using Moq;
using ClaimBridgeBusinessDomain.Repository;
using ClaimBridgeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory; // <-- Add this using directive
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace ClaimBridgeTest
{
    public class InsuranceRepositoryTests
    {
        private PostgresContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<PostgresContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                .Options;
            return new PostgresContext(options);
        }

        [Fact]
        public async Task GetOccupationFactorDetails_ReturnsOccupationFactors()
        {
            // Arrange
            var context = GetInMemoryContext();
            Guid id = Guid.NewGuid();
            context.OccupationDetails.Add(new OccupationDetails { Occupation = "Doctor", OccupationRatingUId = id });
            context.OccupationRatings.Add(new OccupationRating { OccupationRatingUId = id, Factor = 1.2M });
            await context.SaveChangesAsync();

            var repo = new InsuranceRepository(context);

            // Act
            var result = await repo.GetOccupationFactorDetails();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Doctor", result[0].Occupation);
            Assert.Equal(1.2M, result[0].Factor);
        }

        [Fact]
        public async Task SaveUserDetails_SavesUserAndReturnsTrue()
        {
            // Arrange
            var context = GetInMemoryContext();
            var repo = new InsuranceRepository(context);
            var user = new User
            {
                UserUId = Guid.NewGuid(),
                UserName = "TestUser",
                DateOfBirth = DateTime.Parse("1990-01-01"),
                Occupation = "Doctor",
                DeathSumInsured = 100000,
                CreatedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
                RowVersion = DateTime.UtcNow,
                RowStatusUId = Guid.NewGuid()
            };

            // Act
            var result = await repo.SaveUserDetails(user);

            // Assert
            Assert.True(result);
            Assert.Single(context.User);
            Assert.Equal("TestUser", context.User.First().UserName);
        }
    }
}