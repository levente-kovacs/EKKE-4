using BillingStrategy.interfaces;
using BillingStrategy.models;

namespace BillingStrategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BillingContext billingContext = new BillingContext(new RegularBilling());

            double price = 1000;

            Console.WriteLine($"Regular billing is: {billingContext.Checkout(price)}");

            billingContext.SetBillingStrategy(new StudentBilling());

            Console.WriteLine($"Student billing is: {billingContext.Checkout(price)}");
        }
    }
}
