using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgTechTDD_getAlmaAr2.Exceptions
{
    public class AlmaWeightException : Exception // 14.
    {
        public AlmaWeightException(string message) : base(message) { }
    }
}
