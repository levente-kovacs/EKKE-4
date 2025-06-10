using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.models
{
    internal class LegacyPrinter
    {
        public void LegacyPrint(string content)
        {
            Console.WriteLine($"Legacy Printer prints: {content}");
        }
    }
}
