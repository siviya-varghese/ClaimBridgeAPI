using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimBridgeUtilities.Exceptions
{
    public  class InsuranceException:Exception
    {
        public InsuranceException()
        {
        }
        public InsuranceException(string message)
            : base(message)
        {
        }
        public InsuranceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
