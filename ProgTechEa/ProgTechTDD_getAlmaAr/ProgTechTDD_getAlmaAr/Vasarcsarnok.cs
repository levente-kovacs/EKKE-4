using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgTechTDD_getAlmaAr
{
    public class Vasarcsarnok // 4. Vasarcsarnok osztály letrehozasa 5. make it public
    {
        public double AlmaAr { get; set; } // 7. create AlmaAr prop    // 9. make it double

        public double GetAlmaAr(double kg) // 11. create basic GetAlmaAr function
        {
            double price = AlmaAr * kg;

            if (kg >= 20)
                return price *= 0.8;
            if (kg >= 5)
                return price *= 0.9;

            return price;
        }
    }
}
