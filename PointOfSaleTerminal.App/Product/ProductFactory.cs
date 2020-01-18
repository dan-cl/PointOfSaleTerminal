using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PointOfSaleTerminal.App.Product
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

        public bool SetProductId(string productId)
        {
            if (productId.Length != 1 || !productId.All(char.IsLetter))
                return false; 
            
            _product.ProductId = productId.ToUpper();
            return true;
        }

        public bool SetUnitPrice(string unitPrice)
        {
            if (ValidPrice(unitPrice, out var result))
            {
                _product.UnitPrice = result;
                return true;
            }

            return false;
        }

        public bool SetPackSize(string packSize)
        {
            if (int.TryParse(packSize, out var result))
            {
                _product.PackSize = result;
                return true;
            }

            return false;
        }

        public bool SetPackPrice(string packPrice)
        {
            if (ValidPrice(packPrice, out var result))
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

        private static bool ValidPrice(string price, out decimal result)
        {
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var culture = CultureInfo.CreateSpecificCulture("en-AU");
            return decimal.TryParse(price, style, culture, out result);
        }
    }
}
