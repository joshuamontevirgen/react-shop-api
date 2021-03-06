using Core.Domain.Items;
using Core.Domain.Users;
using Core.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Core.DB
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        { }
        internal DbSet<User> Users { get; set; }
        internal DbSet<UserAddress> UserAddresses { get; set; }
        internal DbSet<UserContactDetails> UserContactDetails { get; set; }
        internal DbSet<Item> Items { get; set; }
        internal DbSet<ItemCategory> ItemCategories { get; set; }
        internal DbSet<Order> Orders { get; set; }
        internal DbSet<OrderItem> OrderItems { get; set; }
    }
}
