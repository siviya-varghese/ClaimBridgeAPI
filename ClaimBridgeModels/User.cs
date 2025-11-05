using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimBridgeModels
{
    public class User
    {
        public Guid UserUId { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public decimal DeathSumInsured { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime RowVersion { get; set; }
        public Guid RowStatusUId { get; set; }
    }
}
