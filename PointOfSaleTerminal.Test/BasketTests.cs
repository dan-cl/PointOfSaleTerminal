using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using PointOfSaleTerminal.App;
using Xunit;

namespace PointOfSaleTerminal.Test
{
    public class BasketTests
    {
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

    }
}
