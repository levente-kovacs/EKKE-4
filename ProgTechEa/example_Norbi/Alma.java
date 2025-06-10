package org.example;

public class Alma {
    private double price;
    private Calculator calculator;
    public Alma(double price, Calculator calculator) {
        this.price = price;
        this.calculator = calculator;

    }
    public double getPrice() {
        return this.price;
    }
    public double buy(int quantity){
        if (quantity < 0)
            throw new IllegalArgumentException("A vásárlási mennyiség nem lehet negatív.");
        return calculator.calculate(price, quantity);
    }
}
