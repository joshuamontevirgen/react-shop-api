using System;

namespace Core.Domain.Orders
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int UserAddressId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Total { get; set; }  
    }
}
