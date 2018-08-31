using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarTender.Models
{
    public class DrinkOrder
    {
        public int DrinkOrderId { get; set; }
        public DateTime TimeOrdered { get; set; }
        public decimal TotalPrice { get; set; }
        public Customization Customization { get; set; }
        public int CustomizationId { get; set; }
        public Drink OrderedDrink { get; set; }
        public int DrinkId { get; set; }
        public bool Active { get; set; } = true;

    }
    [Bind]
    public class Customization
    {
        public int CustomizationId { get; set; }
        public bool IsDouble { get; set;}
        public bool HasJuice { get; set; }
        public bool Vegan { get; set; }
        public bool LittleUmbrella { get; set; }
        public bool FrostyMug { get; set;}
        public bool SaltyRim { get; set; }
    }
    [Bind]
    public class Drink
    {
        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
