using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingStrategy.interfaces
{
    internal interface IBillingStrategy
    {
        public double CreateBill(double price);
    }
}
