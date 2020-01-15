using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PointOfSaleTerminal.App
{
    public class Basket
    {
        public List<BasketItem> BasketItems { get; private set; }
        public double BasketTotal { get; private set; }

    }
}
