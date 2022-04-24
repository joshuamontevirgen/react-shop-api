using System;

namespace Core.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
