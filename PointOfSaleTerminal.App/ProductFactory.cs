using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PointOfSaleTerminal.App
{
    public class ProductFactory
    {
        private readonly IProduct _product;

        public ProductFactory()
        {
            _product = new Product();
        }

        public ProductFactory(IProduct product)
        {
            _product = product;
        }

        public bool ValidProductId(string productId)
        {
            if (productId.Length != 1)
                return false; 
            
            _product.ProductId = productId;
            return true;
        }

        public bool ValidUnitPrice(string unitPrice)
        {
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var culture = CultureInfo.CreateSpecificCulture("en-AU");

            if (decimal.TryParse(unitPrice, style, culture, out var number))
            {
                _product.UnitPrice = number;
                return true;

            }

            return false;
        }
    }
}
