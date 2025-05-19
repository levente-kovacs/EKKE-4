package strategy_pattern.models;

import strategy_pattern.interfaces.BillingStrategy;

public class StudentBilling implements BillingStrategy {
    
    @Override
    public double getFinalAmount(double rawAmount) {
        return rawAmount * 0.5;
    }
}
