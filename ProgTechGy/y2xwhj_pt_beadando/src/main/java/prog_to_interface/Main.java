package prog_to_interface;

import adapter_pattern.interfaces.Printer;
import prog_to_interface.models.InkjetPrinter;
import prog_to_interface.models.LaserPrinter;

public class Main {
    public static void main(String[] args) {
        Printer printer;

        printer = new LaserPrinter();
        printer.print("A lot of text...");

        printer = new InkjetPrinter();
        printer.print("High quality images...");
    }
}
