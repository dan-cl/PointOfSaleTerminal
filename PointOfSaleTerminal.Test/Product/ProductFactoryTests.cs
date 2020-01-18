using System.Collections.Generic;
using Moq;
using PointOfSaleTerminal.App.Product;
using Xunit;

namespace PointOfSaleTerminal.Test.Product
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
                productFactory.SetProductId(ValidId);

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
                var result = productFactory.SetProductId(ValidId);

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
                productFactory.SetProductId(invalidId);

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
                var result = productFactory.SetProductId(invalidId);

                //Assert
                Assert.False(result);
            }
        }

        public class ValidUnitPriceTests : ProductFactoryTests
        {

            [Theory()]
            [MemberData(nameof(ValidPriceTestData))]
            public void ValidUnitPrice_PriceIsValid_ReturnsTrue(string validPrice)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.SetUnitPrice(validPrice);

                //Assert
                Assert.True(result);
            }

            [Theory()]
            [MemberData(nameof(ValidPriceTestData))]
            public void ValidUnitPrice_PriceIsValid_SetsTheUnitPrice(string validPrice)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.SetUnitPrice(validPrice);

                //Assert
                mock.VerifySet(x => x.UnitPrice = It.IsAny<decimal>(), Times.Once);
            }

            [Theory()]
            [MemberData(nameof(InvalidPriceTestData))]
            public void ValidUnitPrice_PriceIsInvalid_ReturnsFalse(string invalidPrice)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.SetUnitPrice(invalidPrice);

                //Assert
                Assert.False(result);
            }

            [Theory()]
            [MemberData(nameof(InvalidPriceTestData))]
            public void ValidUnitPrice_PriceIsInvalid_DoesNotSetTheUnitPrice(string invalidPrice)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.SetUnitPrice(invalidPrice);

                //Assert
                mock.VerifySet(x => x.UnitPrice = It.IsAny<decimal>(), Times.Never);
            }
        }

        public class ValidPackSizeTests : ProductFactoryTests
        {
            private const string ValidPackSize1 = "4";
            private const string ValidPackSize2 = "0";
            private const string InvalidPackSize1 = "AA";
            private const string InvalidPackSize2 = "1.5";
            private const string InvalidPackSize3 = "";


            [Theory]
            [InlineData(ValidPackSize1)]
            [InlineData(ValidPackSize2)]
            public void ValidPackSize_PackSizeIsValid_SetsThePackSize(string packSize)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                productFactory.SetPackSize(packSize);

                //Assert
                mock.VerifySet(x => x.PackSize = It.IsAny<int>(), Times.Once);
            }

            [Theory]
            [InlineData(ValidPackSize1)]
            [InlineData(ValidPackSize2)]
            public void ValidPackSize_PackIsValid_ReturnsTrue(string packSize)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.SetPackSize(packSize);

                //Assert
                Assert.True(result);
            }

            [Theory]
            [InlineData(InvalidPackSize1)]
            [InlineData(InvalidPackSize2)]
            [InlineData(InvalidPackSize3)]
            public void ValidPackSize_PackSizeIsInvalid_DoesNotSetThePackSize(string invalidPackSize)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                productFactory.SetPackSize(invalidPackSize);

                //Assert
                mock.VerifySet(x => x.PackSize = It.IsAny<int>(), Times.Never());
            }

            [Theory]
            [InlineData(InvalidPackSize1)]
            [InlineData(InvalidPackSize2)]
            [InlineData(InvalidPackSize3)]
            public void ValidPackSize_PackSizeIsInvalid_ReturnsFalse(string invalidPackSize)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.SetPackSize(invalidPackSize);

                //Assert
                Assert.False(result);
            }
        }

        public class ValidPackPriceTests : ProductFactoryTests
        {

            [Theory()]
            [MemberData(nameof(ValidPriceTestData))]
            public void ValidPackPrice_PriceIsValid_ReturnsTrue(string validPrice)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.SetPackPrice(validPrice);

                //Assert
                Assert.True(result);
            }

            [Theory()]
            [MemberData(nameof(ValidPriceTestData))]
            public void ValidPackPrice_PriceIsValid_SetsThePackPrice(string validPrice)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.SetPackPrice(validPrice);

                //Assert
                mock.VerifySet(x => x.PackPrice = It.IsAny<decimal>(), Times.Once);
            }

            [Theory()]
            [MemberData(nameof(InvalidPriceTestData))]
            public void ValidPackPrice_PriceIsInvalid_ReturnsFalse(string invalidPrice)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.SetPackPrice(invalidPrice);

                //Assert
                Assert.False(result);
            }

            [Theory()]
            [MemberData(nameof(InvalidPriceTestData))]
            public void ValidUnitPrice_PriceIsInvalid_DoesNotSetThePackPrice(string invalidPrice)
            {
                //Arrange
                var mock = new Mock<IProduct>();
                var productFactory = new ProductFactory(mock.Object);

                //Act
                var result = productFactory.SetPackPrice(invalidPrice);

                //Assert
                mock.VerifySet(x => x.PackPrice = It.IsAny<decimal>(), Times.Never);
            }
        }

        public class AddProductToSystemTests : ProductFactoryTests
        {
            private Mock<IProduct> _mockProduct1;
            private Mock<IProduct> _mockProduct2;
            private HashSet<IProduct> _productList;
            private ProductFactory _productFactory;
            //private string productId1 = "A";
            //private string productId2 = "B";


            [Theory]
            [InlineData("A", "B")]
            public void AddProductToSystem_ProductIdIsUnique_AddsTheProductToTheProductHashSet(string productId1, string productId2)
            {
                //Arrange
                SetUpAddProductTest(productId1, productId2);

                //Act
                _productFactory.AddProductToSystem(_productList);

                //Assert
                Assert.True(_productList.Count == 2);
            }

            [Theory]
            [InlineData("A", "A")]
            [InlineData("A", "a")]
            public void AddProductToSystem_ProductIdIsNotUnique_DoesNotAddTheProductToTheProductHashSet(string productId1, string productId2)
            {
                //Arrange
                SetUpAddProductTest(productId1, productId2);

                //Act
                _productFactory.AddProductToSystem(_productList);

                //Assert
                Assert.True(_productList.Count == 1);
            }


            private void SetUpAddProductTest(string productId1, string productId2)
            {
                _mockProduct1 = new Mock<IProduct>();
                _mockProduct2 = new Mock<IProduct>();
                _mockProduct1.Setup(x => x.ProductId).Returns(productId1);
                _mockProduct2.Setup(x => x.ProductId).Returns(productId2);
                _productList = new HashSet<IProduct>(new ProductEqualityComparer()) { _mockProduct1.Object };
                _productFactory = new ProductFactory(_mockProduct2.Object);
            }
        }

        public static IEnumerable<object[]> ValidPriceTestData =>
            new List<object[]>
            {
                new object[] {"$4.87"},
                new object[] {"100.56"},
                new object[] { "0" },
                new object[] { "5" },
                new object[] { "10,000" },
            };

        public static IEnumerable<object[]> InvalidPriceTestData =>
            new List<object[]>
            {
                new object[] {""},
                new object[] {"A"},
                new object[] { "45.67.98" },
                new object[] { "x56" },
            };
    }
}
