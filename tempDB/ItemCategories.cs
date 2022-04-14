using System.Collections.Generic;

namespace WebApplication3.tempDB
{
    public class ItemCategories
    {
        public static List<ItemCategory> _categories = new List<ItemCategory>
        {
            new ItemCategory { Value  = "Frozen", Label = "Frozen"},
                new ItemCategory { Value  = "Meat", Label = "Meat", Parent="Frozen"},
                new ItemCategory { Value  = "Seafood", Label = "Seafood", Parent="Frozen"},
                new ItemCategory { Value  = "Ice Cream", Label = "IceCream", Parent="Frozen"},

            new ItemCategory { Value  = "Beverage", Label = "Beverage"},
                new ItemCategory { Value  = "Water", Label = "Water", Parent="Beverage"},
                new ItemCategory { Value  = "Juice", Label = "Juice", Parent="Beverage"},

            new ItemCategory { Value  = "Snacks", Label = "Snacks"},
                new ItemCategory { Value  = "Cookies", Label = "Cookies", Parent="Snacks"},
                new ItemCategory { Value  = "Candy", Label = "Candy", Parent="Snacks"},

             new ItemCategory { Value  = "Other", Label = "Other"},
        };
    }
}
