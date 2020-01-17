using Moq;
using PointOfSaleTerminal.App;
using Xunit;

namespace PointOfSaleTerminal.Test
{
    public class ProductEqualityComparerTests
    {
        private Mock<IProduct> _mockProduct1;
        private Mock<IProduct> _mockProduct2;
        private IProductEqualityComparer _productEqualityComparer;

        [Theory]
        [InlineData("A", "A")]
        [InlineData("A","a")]
        public void Equals_WhenProductsHaveTheSameId_ReturnsTrueIgnoringCase(string productId1, string productId2)
        {
            //Arrange
            SetupProducts(productId1, productId2);

            //Act
            var result = _productEqualityComparer.Equals(_mockProduct1.Object, _mockProduct2.Object);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_WhenProductsHaveDifferentId_ReturnsFalse()
        {
            //Arrange
            SetupProducts("A", "B");

            //Act
            var result = _productEqualityComparer.Equals(_mockProduct1.Object, _mockProduct2.Object);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void GetHashCode_WhenCalledWithAProductWithUpperCaseProductId_ReturnsHashOfProductId()
        {
            //Arrange
            const string productId = "A";
            var mock = new Mock<IProduct>();
            mock.Setup(x => x.ProductId).Returns(productId);
            var productIdHashCode = productId.GetHashCode();
            _productEqualityComparer = new ProductEqualityComparer();

            //Act
            var result = _productEqualityComparer.GetHashCode(mock.Object);

            //Assert
            Assert.Equal(productIdHashCode, result );
        }

        [Fact]
        public void GetHashCode_WhenCalledWithAProductWithLowerCaseProductId_ReturnsHashOfUpperCaseProductId()
        {
            //Arrange
            var productId = "a";
            var mock = new Mock<IProduct>();
            mock.Setup(x => x.ProductId).Returns(productId);
            var productIdHashCode = productId.ToUpper().GetHashCode();
            _productEqualityComparer = new ProductEqualityComparer();

            //Act
            var result = _productEqualityComparer.GetHashCode(mock.Object);

            //Assert
            Assert.Equal(productIdHashCode, result);
        }


        private void SetupProducts(string productId1, string productId2)
        {
            _mockProduct1 = new Mock<IProduct>();
            _mockProduct2 = new Mock<IProduct>();
            _mockProduct1.Setup(x => x.ProductId).Returns(productId1);
            _mockProduct2.Setup(x => x.ProductId).Returns(productId2);
            _productEqualityComparer = new ProductEqualityComparer();
        }
    }
}
