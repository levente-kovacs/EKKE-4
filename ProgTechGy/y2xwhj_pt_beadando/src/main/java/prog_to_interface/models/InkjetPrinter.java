package prog_to_interface.models;

import adapter_pattern.interfaces.Printer;

public class InkjetPrinter implements Printer {
    @Override
    public void print(String text) {
        System.out.println("Inkjet Printer is printing: " + text);
    }
}