using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimBridgeModels
{
    public class UserRequest
    {
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public decimal DeathSumInsured { get; set; }
    }
}
