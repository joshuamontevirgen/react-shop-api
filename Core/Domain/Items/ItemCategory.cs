using System.Collections.Generic;

namespace Core.Domain.Items
{
    public class ItemCategory : BaseEntity
    {
        public string Value { get; set; }
        public string Label { get; set; }

        public int? ParentId { get; set; }
    }
}
