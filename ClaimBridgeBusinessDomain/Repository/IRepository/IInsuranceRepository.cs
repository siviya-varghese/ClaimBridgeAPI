using ClaimBridgeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimBridgeBusinessDomain.Repository.IRepository
{
    public interface IInsuranceRepository
    {
        Task<List<OccupationFactorDetailsResponse>> GetOccupationFactorDetails();
        Task<bool> SaveUserDetails(User user);
    }
}
