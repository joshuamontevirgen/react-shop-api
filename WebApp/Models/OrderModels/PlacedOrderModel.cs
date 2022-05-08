using Core.Payments;

namespace WebApplication3.Models.OrderModels
{
    public class PlacedOrderModel : OrderModel
    {
        public ProcessPaymentResult PaymentProcess { get; set; }
    }
}
