using Xunit;
using Moq;
using ClaimBridgeBusinessDomain.BusinessLayer;
using ClaimBridgeBusinessDomain.Repository.IRepository;
using ClaimBridgeModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClaimBridgeTest
{
    public class InsuranceBusinessLayerTests
    {
        private readonly Mock<IInsuranceRepository> _mockRepo;
        private readonly InsuranceBusinessLayer _businessLayer;

        public InsuranceBusinessLayerTests()
        {
            _mockRepo = new Mock<IInsuranceRepository>();
            _businessLayer = new InsuranceBusinessLayer(null, _mockRepo.Object);
        }

        [Fact]
        public async Task GetOccupationFactorDetails_ReturnsDetails_WhenDataExists()
        {
            // Arrange
            var expected = new List<OccupationFactorDetailsResponse>
            {
                new OccupationFactorDetailsResponse { /* set properties as needed */ }
            };
            _mockRepo.Setup(r => r.GetOccupationFactorDetails()).ReturnsAsync(expected);

            // Act
            var result = await _businessLayer.GetOccupationFactorDetails();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Count, result.Count);
        }

        [Fact]
        public async Task GetOccupationFactorDetails_ReturnsEmpty_WhenNoData()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetOccupationFactorDetails()).ReturnsAsync(new List<OccupationFactorDetailsResponse>());

            // Act
            var result = await _businessLayer.GetOccupationFactorDetails();

            // Assert
            Assert.Empty(result);
        }
    }
}