package org.example;

public class TenPercentDiscount implements Discount {
    double discount = 0.9;

    @Override
    public double getDiscount() {
        return discount;
    }
}
