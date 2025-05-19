package prog_to_interface.models;

import adapter_pattern.interfaces.Printer;

public class LaserPrinter implements Printer {

    @Override
    public void print(String text) {
        System.out.println("Laser Printer is printing: " + text);
    }
}
