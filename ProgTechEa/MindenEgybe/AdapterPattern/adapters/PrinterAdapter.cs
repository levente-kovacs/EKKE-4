using AdapterPattern.interfaces;
using AdapterPattern.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.adapters
{
    internal class PrinterAdapter : IPrinter
    {
        private LegacyPrinter legacyPrinter;

        public PrinterAdapter(LegacyPrinter legacyPrinter)
        {
            this.legacyPrinter = legacyPrinter;
        }

        public void Print(string content)
        {
            legacyPrinter.LegacyPrint(content);
        }
    }
}
