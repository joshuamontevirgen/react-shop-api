﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Users
{
    public class UserAddress : BaseEntity
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

    }
}
