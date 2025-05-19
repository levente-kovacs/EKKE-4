package strategy_pattern.models;

import strategy_pattern.interfaces.BillingStrategy;

public class RegularBilling implements BillingStrategy {
    
    @Override
    public double getFinalAmount(double rawAmount) {
        return rawAmount;
    }
}
