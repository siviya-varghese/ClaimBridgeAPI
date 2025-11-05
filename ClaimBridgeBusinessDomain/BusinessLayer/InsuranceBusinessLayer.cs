using ClaimBridgeBusinessDomain.Interface;
using ClaimBridgeBusinessDomain.Repository.IRepository;
using ClaimBridgeModels;

namespace ClaimBridgeBusinessDomain.BusinessLayer
{

    public class InsuranceBusinessLayer: IInsuranceBusinessLayer
    {
        private PostgresContext _postgresContext;
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceBusinessLayer(PostgresContext postgresContext, IInsuranceRepository insuranceRepository)
        {
            _postgresContext = postgresContext;
            _insuranceRepository = insuranceRepository;
        }

        public async Task<List<OccupationFactorDetailsResponse>> GetOccupationFactorDetails()
        {

            return await _insuranceRepository.GetOccupationFactorDetails();
        }

        public async Task<bool> SaveUserDetails(UserRequest user)
        {
            var userObj = new User
            {
                UserUId = Guid.NewGuid(),
                UserName = user.UserName,
                DateOfBirth = user.DateOfBirth,
                Occupation = user.Occupation,
                DeathSumInsured = user.DeathSumInsured
            };
            var result = await _insuranceRepository.SaveUserDetails(userObj);
            return result;
        }
    }
}
