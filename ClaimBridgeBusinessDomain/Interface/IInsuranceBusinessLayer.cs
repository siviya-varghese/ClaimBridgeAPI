using ClaimBridgeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimBridgeBusinessDomain.Interface
{
    public interface IInsuranceBusinessLayer
    {
        Task<List<OccupationFactorDetailsResponse>> GetOccupationFactorDetails();
        Task<bool> SaveUserDetails(UserRequest user);
    }
}
