using System.ComponentModel.DataAnnotations;

namespace PointOfSaleTerminal.App
{
    public interface IProduct
    {
        string ProductId { get; set; }
        double UnitPrice { get; }
        int PackSize { get; }
        double PackPrice { get; }
    }

    public class Product : IProduct
    {
        public string ProductId { get; set; }
        public double UnitPrice { get; }   
        public int PackSize { get; }
        public double PackPrice { get; }

        public Product()
        {
            
        }
    }
}
