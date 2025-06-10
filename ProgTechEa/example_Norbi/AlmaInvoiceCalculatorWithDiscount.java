package org.example;

public class AlmaInvoiceCalculatorWithDiscount implements Calculator {
    private Discount discount;
    public AlmaInvoiceCalculatorWithDiscount() {
        discount = new NoDiscount();
    }
    @Override
    public double calculate(double price, int quantity){
        return price * quantity * discount.getDiscount();
    }

    @Override
    public void setDiscount(Discount discount) {
        this.discount = discount;
    }
}
