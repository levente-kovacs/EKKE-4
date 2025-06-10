using ProgTechTDD_getAlmaAr2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgTechTDD_getAlmaAr2
{
    public class Vasarcsarnok // 3.
    {
        public double AlmaAr { get; set; } // 4.

        public double GetAlmaAr(double weight) // 6. létrehozás, 8. alap működés
        {
            if (weight <= 0 || weight > 100) // 14.
            {
                throw new AlmaWeightException("A vásárolt almának többnek kell lennie, mint 0kg; illetve kevesebbnek, mint 100kb");
            }

            double price = AlmaAr * weight;

            if (weight >= 20) // 12. 20% kedvezmény
            {
                price *= 0.8;
            }
            else if (weight >= 5) // 10. 10% kedvezmény
            {
                price *= 0.9;
            }

            return price;
        }
    }
}
