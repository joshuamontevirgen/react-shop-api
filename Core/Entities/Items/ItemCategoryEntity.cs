using Core.Domain.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Items
{
    internal class ItemCategoryEntity : ItemCategory
    {
        internal List<ItemEntity> Items { get; set; }

        [ForeignKey("ParentId")]
        internal ItemCategoryEntity Parent { get; set; }
        internal List<ItemCategoryEntity> Children { get; set; }
    }
}
