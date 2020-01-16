using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using PointOfSaleTerminal.App;
using Xunit;

namespace PointOfSaleTerminal.Test
{
    public class ProductFactoryTests
    {
        [Fact]
        public void ValidProductId_IdIsValid_SetsTheProductId()
        {
            var mock = new Mock<IProduct>();
            var productFactory = new ProductFactory(mock.Object);
            var id = "A";

            productFactory.ValidProductId(id);

            mock.VerifySet(x => x.ProductId = id);
        }

        [Fact]
        public void ValidProductId_IdIsValid_ReturnsTrue()
        {
            var mock = new Mock<IProduct>();
            var productFactory = new ProductFactory(mock.Object);
            var id = "A";

            var result = productFactory.ValidProductId(id);

            Assert.True(result);
        }

    }
}
