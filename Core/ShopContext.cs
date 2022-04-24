﻿using Core.Domain.Items;
using Core.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Core.DB
{
    internal class ShopContext : DbContext
    {
        internal ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        { }
        internal DbSet<User> Users { get; set; }
        internal DbSet<UserAddress> UserAddresses { get; set; }
        internal DbSet<UserContactDetails> UserContactDetails { get; set; }
        internal DbSet<Item> Items { get; set; }
        internal DbSet<ItemCategory> ItemCategories { get; set; }
    }
}
