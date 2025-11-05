using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimBridgeModels
{
    public class OccupationRating
    {

        public string Rating { get; set; }
        public decimal Factor { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime RowVersion { get; set; }
        public Guid RowStatusUId { get; set; }
    }
}
