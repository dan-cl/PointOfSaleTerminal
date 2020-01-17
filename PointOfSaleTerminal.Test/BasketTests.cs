using System.Collections.Generic;
using System.Linq;
using Moq;
using PointOfSaleTerminal.App;
using Xunit;

namespace PointOfSaleTerminal.Test
{
    public class BasketTests
    {
        private Mock<IProduct> _mockProductA;
        private Mock<IProduct> _mockProductB;
        private Mock<IProduct> _mockProductC;
        private Mock<IProduct> _mockProductD;

        [Fact]
        public void AddToBasket_ProductNotAlreadyInBasket_AddsProductToBasket()
        {
            //Arrange
            var basket = new Basket();
            var mock = new Mock<IProduct>();

            //Act
            var emptyBasketCount = basket.BasketItems.Count;
            basket.AddToBasket(mock.Object);

            //Assert
            Assert.True(emptyBasketCount == 0);
            Assert.True(basket.BasketItems.Count == 1);
        }

        [Fact]
        public void AddToBasket_ProductAlreadyInBasket_DoesNotAddProductToBasket()
        {
            //Arrange
            var basket = new Basket();
            var mock = new Mock<IProduct>();

            //Act
            var emptyBasketCount = basket.BasketItems.Count;
            basket.AddToBasket(mock.Object);
            basket.AddToBasket(mock.Object);

            //Assert
            Assert.True(emptyBasketCount == 0);
            Assert.True(basket.BasketItems.Count == 1);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void CalculateBasketTotal_CalculatesTheCorrectTotal(List<int> listOfQuantities, decimal expectedPrice)
        {
            //Arrange
            var productList = new List<IProduct>();
            var basket = new Basket();

            SetupMockProducts(productList);

            //combines products and respective test quantities
            var productsAndQuantities = productList.Zip(listOfQuantities, (p, q) => new { Product = p, Quantity = q });

            //adds products and respective test quantities to the basket
            foreach (var item in productsAndQuantities)
            {
                SetupMockBasketItem(basket, item.Product, item.Quantity);
            }

            //Act
            var result = basket.CalculateBasketTotal();

            //Assert
            Assert.Equal(expectedPrice, result);
        }

        //
        private void SetupMockProducts(IList<IProduct> mockProductList)
        {
            _mockProductA = new Mock<IProduct>();
            _mockProductA.SetupAllProperties();
            _mockProductA.Object.ProductId = "A";
            _mockProductA.Object.UnitPrice = 1.25M;
            _mockProductA.Object.PackSize = 3;
            _mockProductA.Object.PackPrice = 3.00M;
            _mockProductA.Object.DiscountPerPack = 0.75M;
            mockProductList.Add(_mockProductA.Object);

            _mockProductB = new Mock<IProduct>();
            _mockProductB.SetupAllProperties();
            _mockProductB.Object.ProductId = "B";
            _mockProductB.Object.UnitPrice = 4.25M;
            _mockProductB.Object.PackSize = 0;
            _mockProductB.Object.PackPrice = 0M;
            _mockProductB.Object.DiscountPerPack = 0M;
            mockProductList.Add(_mockProductB.Object);

            _mockProductC = new Mock<IProduct>();
            _mockProductC.SetupAllProperties();
            _mockProductC.Object.ProductId = "C";
            _mockProductC.Object.UnitPrice = 1M;
            _mockProductC.Object.PackSize = 6;
            _mockProductC.Object.PackPrice = 5M;
            _mockProductC.Object.DiscountPerPack = 1M;
            mockProductList.Add(_mockProductC.Object);

            _mockProductD = new Mock<IProduct>();
            _mockProductD.SetupAllProperties();
            _mockProductD.Object.ProductId = "D";
            _mockProductD.Object.UnitPrice = 0.75M;
            _mockProductD.Object.PackSize = 0;
            _mockProductD.Object.PackPrice = 0M;
            _mockProductD.Object.DiscountPerPack = 0M;
            mockProductList.Add(_mockProductD.Object);
        }

        private static void SetupMockBasketItem(IBasket basket, IProduct product, int quantity)
        {
            var mockProductBasketItem = new Mock<IBasketItem>();
            mockProductBasketItem.SetupAllProperties();
            mockProductBasketItem.Object.Product = product;
            mockProductBasketItem.Object.Quantity = quantity;
            basket.BasketItems.Add(mockProductBasketItem.Object);
        }

        //quantity and price test data
        public static IEnumerable<object[]> GetTestData =>
            new List<object[]>
            {
                //quantities for products {A, B, C, D}, and expected total price
                new object[] {new List<int> {3, 2, 1, 1}, 13.25M},
                new object[] {new List<int> {0, 0, 7, 0}, 6.00M},
                new object[] {new List<int> {1, 1, 1, 1}, 7.25M}
            };
    }
}
