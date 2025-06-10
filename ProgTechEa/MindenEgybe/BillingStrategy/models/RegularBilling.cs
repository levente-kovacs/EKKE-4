using BillingStrategy.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingStrategy.models
{
    internal class RegularBilling : IBillingStrategy
    {
        public double CreateBill(double price)
        {
            return price * 1.27;
        }
    }
}
