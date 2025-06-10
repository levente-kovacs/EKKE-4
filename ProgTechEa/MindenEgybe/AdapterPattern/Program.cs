using AdapterPattern.adapters;
using AdapterPattern.interfaces;

namespace AdapterPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPrinter printer = new PrinterAdapter(new models.LegacyPrinter());
            printer.Print("This text was printed through the new simpler IPrint interface's method.");
        }
    }
}
