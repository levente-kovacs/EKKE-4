﻿using BillingStrategy.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingStrategy.models
{
    internal class StudentBilling : IBillingStrategy
    {
        public double CreateBill(double price)
        {
            return price * 0.5;
        }
    }
}
