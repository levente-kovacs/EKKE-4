package org.example;

public class NoDiscount implements Discount {

    @Override
    public double getDiscount() {
        return 1.0;
    }
}
