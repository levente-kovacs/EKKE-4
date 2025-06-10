import org.example.*;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class AlmaPriceTest {
    private Alma alma;
    private Calculator calculator;
    
    @BeforeEach
    void setUp() {
        calculator = new AlmaInvoiceCalculatorWithDiscount();
        alma = new Alma(1000, calculator);

    }

    @DisplayName("Alma osztály létrehozása")
    @Test
    public void createAlma(){
        Alma újAlma = new Alma(1000, calculator);
    }

    @DisplayName("1000 Ft-nak megfelelő ár")
    @Test
    public void getAlmaPrice(){
        double expected = 1000.0;
        double actual = alma.getPrice();
        assertEquals(actual,expected);
    }

    @DisplayName("Vásárlás 0 kg")
    @Test
    public void buyALma(){
        double expected = 0.0;
        double actual = alma.buy(0);
        assertEquals(expected,actual);
    }
    
    @DisplayName("Vásárlás 1kg")
    @Test
    public void buyAlmaWith1kg(){
        double expected = 1000.0;
        double actual = alma.buy(1);
        assertEquals(expected,actual);
    }

    @DisplayName("Vásárlás 5kg")
    @Test
    public void buyAlmaWith5kg(){
        Discount discount = new TenPercentDiscount();
        calculator.setDiscount(discount);
        double expected = 4500.0;
        double actual = alma.buy(5);
        assertEquals(expected,actual);
    }

    @DisplayName("Vásárlás 10kg")
    @Test
    public void buyAlmaWith10kg(){
        Discount discount = new FifteenPercentDiscount();
        calculator.setDiscount(discount);
        double expected = 8500.0;
        double actual = alma.buy(10);
        assertEquals(expected,actual);
    }

    @DisplayName("Vásárlás 10kg - akció nélkül")
    @Test
    public void buyAlmaWith10kgWithoutDiscount(){
        double expected = 10000.0;
        double actual = alma.buy(10);
        assertEquals(expected,actual);
    }

    @DisplayName("Negatív mennyiségi vásárlás")
    @Test
    public void buyNegative(){
        assertThrows(IllegalArgumentException.class, () -> {
            alma.buy(-1);
        });
    }

}
