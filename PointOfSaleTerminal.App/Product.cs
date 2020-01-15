namespace PointOfSaleTerminal.App
{
    public class Product
    {
        public string ProductCode { get; }
        public double UnitPrice { get; }   
        public int PackSize { get; }
        public double PackPrice { get; }

        public Product(string productCode, double unitPrice)
        {
            ProductCode = productCode;
            UnitPrice = unitPrice;
        }

        public Product(string productCode, double unitPrice, int packSize, double packPrice)
        {
            ProductCode = productCode;
            UnitPrice = unitPrice;
            PackSize = packSize;
            PackPrice = packPrice;
        }
    }
}
