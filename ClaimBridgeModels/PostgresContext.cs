using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimBridgeModels
{
    public class PostgresContext : DbContext
    {
        public PostgresContext()
        {

        }
        public virtual DbSet<OccupationDetails> OccupationDetails { get; set; }
        public virtual DbSet<OccupationRating> OccupationRatings { get; set; }

    }
}
