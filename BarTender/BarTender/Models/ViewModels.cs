using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace BarTender.Models
{
    public class AddIngredientViewModel
    {

        public int drinkId { get; set; }
        public Customization custom { get; set; }
        public string [] customizationOptions { get; set; }
        public Drink drinkOrder { get; set; }
    }
}
