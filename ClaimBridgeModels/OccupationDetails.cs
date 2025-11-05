using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimBridgeModels
{
    public class OccupationDetails
    {
        public Guid OccupationDetailsUId { get; set; }
        public string Occupation { get; set; }

        public string Rating { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime RowVersion { get; set; }
        public Guid RowStatusUId { get; set; }
    }
}
