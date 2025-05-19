package adapter_pattern;

import adapter_pattern.adapters.PrinterAdapter;
import adapter_pattern.interfaces.Printer;
import adapter_pattern.models.LegacyPrinter;

public class Main {
    public static void main(String[] args) {
        LegacyPrinter legacyPrinter = new LegacyPrinter();
        Printer printer = new PrinterAdapter(legacyPrinter);

        printer.print("Hello adapter pattern!");
    }
}
