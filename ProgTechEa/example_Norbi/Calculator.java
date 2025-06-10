package org.example;

public interface Calculator {
    double calculate(double price, int quantity);
    void setDiscount(Discount discount);
}
