package adapter_pattern.adapters;

import adapter_pattern.interfaces.Printer;
import adapter_pattern.models.LegacyPrinter;

public class PrinterAdapter implements Printer {
    private LegacyPrinter legacyPrinter;

    public PrinterAdapter(LegacyPrinter legacyPrinter) {
        this.legacyPrinter = legacyPrinter;
    }

    @Override
    public void print(String text) {
        legacyPrinter.printText(text);
    }
}
