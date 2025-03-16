using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingApplication.Test
{
    public class OrderServiceTest
    {
        [Fact]
        public void GetOrder_ShouldReturnOK()
        {
            // Arrange
            var orderService = new OrderService();

            // Act
            var result = orderService.GetOrder();

            // Assert
            Assert.Equal(100, result);
        }
    }
}
