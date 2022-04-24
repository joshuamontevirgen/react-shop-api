using Core.Domain.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Items
{
    internal class ItemEntity : Item
    {
        [ForeignKey("ItemCategoryId")]
        internal virtual ItemCategoryEntity Category { get; set; }


    }
}
