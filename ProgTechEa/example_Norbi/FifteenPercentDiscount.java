package org.example;

public class FifteenPercentDiscount implements Discount{
    private double discount = 0.85;
    @Override
    public double getDiscount() {
        return discount;
    }
}
