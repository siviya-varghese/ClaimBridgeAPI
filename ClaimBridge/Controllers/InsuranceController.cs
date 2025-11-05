using ClaimBridgeBusinessDomain.Interface;
using ClaimBridgeModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceBusinessLayer _insuranceBusinessLayer;
        public InsuranceController(IInsuranceBusinessLayer insuranceBusinessLayer)
        {
            insuranceBusinessLayer = _insuranceBusinessLayer;
        }


        [HttpGet("GetOccupationFactorDetails")]
        public async Task<IActionResult> GetOccupationFactorDetails()
        {
            try
            {
                var details = await _insuranceBusinessLayer.GetOccupationFactorDetails();
                if (details == null || !details.Any())
                    return NoContent();

                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpPost("SaveUserDetails")]
        public async Task<IActionResult> SaveUserDetails([FromBody] UserRequest user)
        {
            try
            {
                if (user == null)
                    return BadRequest(new { error = "User payload is required." });

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var saved = await _insuranceBusinessLayer.SaveUserDetails(user);
                if (saved)
                    return Ok(new { success = true });

                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Failed to save user details." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}
