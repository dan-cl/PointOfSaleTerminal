using System.Runtime.InteropServices.ComTypes;
using Moq;
using PointOfSaleTerminal.App;
using Xunit;

namespace PointOfSaleTerminal.Test
{
    public class ProductFactoryTests
    {
        public class ValidProductTests : ProductFactoryTests
        {
            private const string ValidId = "A";
            private const string InvalidId1 = "AA";
            private const string InvalidId2 = "";

            [Fact]
            public void ValidProductId_IdIsValid_SetsTheProductId()
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                productFactory.ValidProductId(ValidId);

                //Assert
                mock.VerifySet(x => x.ProductId = ValidId);
            }

            [Fact]
            public void ValidProductId_IdIsValid_ReturnsTrue()
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.ValidProductId(ValidId);

                //Assert
                Assert.True(result);
            }

            [Theory]
            [InlineData(InvalidId1)]
            [InlineData(InvalidId2)]
            public void ValidProductId_IdIsInvalid_DoesNotSetTheProductId(string invalidId)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                productFactory.ValidProductId(invalidId);

                //Assert
                mock.VerifySet(x => x.ProductId = It.IsAny<string>(), Times.Never());
            }

            [Theory]
            [InlineData(InvalidId1)]
            [InlineData(InvalidId2)]
            public void ValidProductId_IdIsInvalid_ReturnsFalse(string invalidId)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.ValidProductId(invalidId);

                //Assert
                Assert.False(result);
            }
        }

        public class ValidUnitPriceTests : ProductFactoryTests
        {
            private const string ValidPrice1 = "$4.87";
            private const string ValidPrice2 = "100.56";
            private const string ValidPrice3 = "0";
            private const string ValidPrice4 = "5";
            private const string ValidPrice5 = "10,000";


            private const string InvalidPrice1 = "";
            private const string InvalidPrice2 = "A";
            private const string InvalidPrice3 = "45.67.98";
            private const string InvalidPrice4 = "x56";

            [Theory()]
            [InlineData(ValidPrice1)]
            [InlineData(ValidPrice2)]
            [InlineData(ValidPrice3)]
            [InlineData(ValidPrice4)]
            [InlineData(ValidPrice5)]
            public void ValidUnitPrice_PriceIsValid_ReturnsTrue(string validPrice)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.ValidUnitPrice(validPrice);

                //Assert
                Assert.True(result);
            }

            [Theory()]
            [InlineData(ValidPrice1)]
            [InlineData(ValidPrice2)]
            [InlineData(ValidPrice3)]
            [InlineData(ValidPrice4)]
            [InlineData(ValidPrice5)]
            public void ValidUnitPrice_PriceIsValid_SetsTheUnitPrice(string validPrice)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.ValidUnitPrice(validPrice);

                //Assert
                mock.VerifySet(x => x.UnitPrice = It.IsAny<decimal>(), Times.Once);
            }

            [Theory()]
            [InlineData(InvalidPrice1)]
            [InlineData(InvalidPrice2)]
            [InlineData(InvalidPrice3)]
            [InlineData(InvalidPrice4)]
            public void ValidUnitPrice_PriceIsInvalid_ReturnsFalse(string invalidPrice)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.ValidUnitPrice(invalidPrice);

                //Assert
                Assert.False(result);
            }

            [Theory()]
            [InlineData(InvalidPrice1)]
            [InlineData(InvalidPrice2)]
            [InlineData(InvalidPrice3)]
            [InlineData(InvalidPrice4)]
            public void ValidUnitPrice_PriceIsInvalid_DoesNotSetTheUnitPrice(string invalidPrice)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.ValidUnitPrice(invalidPrice);

                //Assert
                mock.VerifySet(x => x.UnitPrice = It.IsAny<decimal>(), Times.Never);
            }
        }
    }
}
