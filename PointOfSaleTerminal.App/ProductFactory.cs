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
    }
}
