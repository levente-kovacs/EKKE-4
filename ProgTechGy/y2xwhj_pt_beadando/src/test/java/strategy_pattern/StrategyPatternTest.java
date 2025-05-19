package strategy_pattern;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertNotEquals;

import org.junit.jupiter.api.Test;

import strategy_pattern.contexts.BillingContext;
import strategy_pattern.models.StudentBilling;

public class StrategyPatternTest {
    BillingContext context = new BillingContext(new StudentBilling());
    
    @Test
    void testStudentBillingRight() {
        assertEquals(500.0, context.checkout(1000.0));
    }

    @Test
    void testStudentBillingWrong() {
        assertNotEquals(1000, context.checkout(1000.0));
    }
}
