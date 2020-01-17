namespace PointOfSaleTerminal.App
{
    public interface IProduct
    {
        string ProductId { get; set; }
        decimal UnitPrice { get; set; }
        int PackSize { get; set; }
        decimal PackPrice { get; set; }
        decimal DiscountPerPack { get; set; }
    }

    public class Product : IProduct
    {
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set;  }   
        public int PackSize { get; set;  }
        public decimal PackPrice { get; set;  }

        public decimal DiscountPerPack
        {
            get => GetDiscountPerPack();
            set { }
        }
        

        private decimal GetDiscountPerPack()
        {
            var fullPrice = UnitPrice * PackSize;
            var discount = fullPrice - PackPrice;
            return discount;
        }
    }
}
