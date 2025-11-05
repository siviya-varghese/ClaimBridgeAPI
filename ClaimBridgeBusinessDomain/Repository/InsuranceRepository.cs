using ClaimBridgeBusinessDomain.Repository.IRepository;
using ClaimBridgeModels;
using ClaimBridgeUtilities;
using ClaimBridgeUtilities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ClaimBridgeBusinessDomain.Repository
{
    public class InsuranceRepository: IInsuranceRepository
    {
        private PostgresContext _postgresContext;
        public InsuranceRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }
        public async Task<List<OccupationFactorDetailsResponse>> GetOccupationFactorDetails()
        {
            try
            {

                var result = await (from occupationDetails in _postgresContext.OccupationDetails
                                    join occupationRating in _postgresContext.OccupationRatings
                                     on occupationDetails.OccupationRatingUId equals occupationRating.OccupationRatingUId
                                    select new OccupationFactorDetailsResponse
                                    {
                                        Occupation = occupationDetails.Occupation,
                                        Factor = occupationRating.Factor
                                    }).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new InsuranceException(Constants.GetOccupationFactorDetailsException, ex);
            }
        }

        public async Task<bool> SaveUserDetails(User user)
        {
            try
            {
                await _postgresContext.User.AddAsync(user);
                await _postgresContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InsuranceException(Constants.SaveUserDetailsException, ex);
            }
        }
    }
}
