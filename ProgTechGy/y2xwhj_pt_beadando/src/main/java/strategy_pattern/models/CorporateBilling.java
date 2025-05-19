package strategy_pattern.models;

import strategy_pattern.interfaces.BillingStrategy;

public class CorporateBilling  implements BillingStrategy {
    
    @Override
    public double getFinalAmount(double rawAmount) {
        return rawAmount * 1.27;
    }
}
