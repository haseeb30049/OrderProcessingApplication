using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingApplication.Test
{
    internal class OrderService:IOrderService
    {
        public double GetOrder() {
            return 100;
        }
    }
}
