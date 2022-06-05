using StoreModel;
using Xunit;

namespace AppTest
{
    public class StoreModelTest
    {
        //This is how C#/XUnit recognizes that this particular method will be a unit test
        //Data annotation - They just add special metadata information that gives special properties to a particular class member
        [Fact]
        public void CustomerNumber_Should_Set_ValidData()
        {
            //Arrange

            Customer appobj = new Customer();
            int CustomerNumber = 15;
            //Act
            appobj.CustomerID = CustomerNumber;
            //Assert 
            Assert.NotNull(appobj.CustomerID);
            Assert.Equal(CustomerNumber,appobj.CustomerID);
        }

        [Fact]
        public void CustomerNumber_Should_Fail_Set_InvalidData()
        {
            // Arrange
            Customer appobj = new Customer();
            // Act 
            // Then
        }
    }
}
