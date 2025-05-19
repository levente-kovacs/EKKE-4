package strategy_pattern;

import strategy_pattern.contexts.BillingContext;
import strategy_pattern.models.CorporateBilling;
import strategy_pattern.models.RegularBilling;
import strategy_pattern.models.StudentBilling;

public class Main {
    public static void main(String[] args) {
        BillingContext billing = new BillingContext(new RegularBilling());

        double basePrice = 1000;

        System.out.println("Regular customer: " + billing.checkout(basePrice));

        billing.setStrategy(new StudentBilling());
        System.out.println("Student customer: " + billing.checkout(basePrice));

        billing.setStrategy(new CorporateBilling());
        System.out.println("Corporate customer: " + billing.checkout(basePrice));
    }
}
