using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
            if (productId.Length != 1 || !productId.All(char.IsLetter))
                return false; 
            
            _product.ProductId = productId.ToUpper();
            return true;
        }

        public bool ValidUnitPrice(string unitPrice)
        {
            if (ValidatePrice(unitPrice, out var result))
            {
                _product.UnitPrice = result;
                return true;
            }

            return false;
        }

        public bool ValidPackSize(string packSize)
        {
            if (int.TryParse(packSize, out var result))
            {
                _product.PackSize = result;
                return true;
            }

            return false;
        }

        public bool ValidPackPrice(string packPrice)
        {
            if (ValidatePrice(packPrice, out var result))
            {
                _product.PackPrice = result;
                return true;
            }

            return false;
        }

        public void AddProductToSystem(HashSet<IProduct> productList)
        {
            productList.Add(_product);
        }

        private static bool ValidatePrice(string price, out decimal result)
        {
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var culture = CultureInfo.CreateSpecificCulture("en-AU");
            return decimal.TryParse(price, style, culture, out result);
        }
    }
}
