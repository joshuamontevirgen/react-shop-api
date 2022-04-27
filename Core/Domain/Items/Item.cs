using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Items
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int ItemCategoryId { get; set; }
    }
}
