using BillingStrategy.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingStrategy
{
    internal class BillingContext
    {
        private IBillingStrategy _billingStrategy;

        public BillingContext(IBillingStrategy billingStrategy)
        {
            _billingStrategy = billingStrategy;
        }

        public void SetBillingStrategy(IBillingStrategy billingStrategy)
        {
            _billingStrategy = billingStrategy;
        }

        public double Checkout(double price)
        {
            return _billingStrategy.CreateBill(price);
        }
    }
}
