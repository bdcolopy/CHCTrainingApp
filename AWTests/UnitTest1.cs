using AWProducts;
using NSubstitute;
using NUnit.Framework;

namespace AWTests
{
    public class Tests
    {
        private readonly ISalesData _mockAWSales;


        [SetUp]
        public void Setup()
        {
            _mockAWRepo = Substitute.For<ISalesData>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
            //Arrange
            //Act
            //Assert
        }
    }
}