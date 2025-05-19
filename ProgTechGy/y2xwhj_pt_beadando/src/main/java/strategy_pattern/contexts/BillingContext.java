package strategy_pattern.contexts;

import strategy_pattern.interfaces.BillingStrategy;

public class BillingContext {
    private BillingStrategy strategy;

    public BillingContext(BillingStrategy strategy) {
        this.strategy = strategy;
    }

    public void setStrategy(BillingStrategy strategy) {
        this.strategy = strategy;
    }

    public double checkout(double amount) {
        return strategy.getFinalAmount(amount);
    }
    
}
