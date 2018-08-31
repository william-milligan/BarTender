using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarTender.Models;
using Microsoft.AspNetCore.Mvc;


namespace BarTender.Controllers
{
    public class HomeController : Controller
    {
        BartenderDBContext data;

        public HomeController(BartenderDBContext _data)
        {
            data = _data;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Drink> DrinksForMenu = data.Drinks;

            return View(DrinksForMenu);
        }

        [HttpPost]
        public IActionResult AddIngredients(int DrinkId)
        {
            Drink drinkizzle = data.Drinks.Find(DrinkId);
            AddIngredientViewModel AIVM = new AddIngredientViewModel
            {
                drinkOrder = drinkizzle,
                drinkId = DrinkId,
                custom = new Customization(),
                customizationOptions = new string[] {"Make Double","Add Juice","Make Vegan", "Add Little Umbrella", "Add Frosty Mug", "Salt on the Rim"}
                
            };
            return View(AIVM);
        }
        [HttpPost]
        public IActionResult MakeOrder(AddIngredientViewModel AIVM)
        {
            Drink drink = data.Drinks.Find(AIVM.drinkId);
            data.Add(AIVM.custom);
            data.SaveChanges();
            decimal Price = drink.Price;
            if(AIVM.custom.FrostyMug == true)
            {
                Price += (decimal)1.50;
            }
            if(AIVM.custom.HasJuice == true)
            {
                Price += (decimal)2.50;
            }
            if(AIVM.custom.IsDouble == true)
            {
                Price += (decimal)4.75;
            }
            if(AIVM.custom.LittleUmbrella == true)
            {
                Price -= (decimal).75;
            }
            if(AIVM.custom.SaltyRim == true)
            {
                Price += (decimal).75;
            }
            if(AIVM.custom.Vegan == true)
            {
                Price += (decimal).15;
            }
            DrinkOrder order = new DrinkOrder
            {
                Customization = AIVM.custom,
                OrderedDrink = drink,
                CustomizationId = AIVM.custom.CustomizationId,
                DrinkId = AIVM.drinkId,
                TimeOrdered = DateTime.Now,
                TotalPrice = Price
            };
            data.Add(order);
            data.SaveChanges();
            return View("Index", data.Drinks);
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            IEnumerable<DrinkOrder> orders = data.DrinkOrders;
            foreach(DrinkOrder drink in orders)
            {
                drink.OrderedDrink = data.Drinks.Find(drink.DrinkId);
                drink.Customization = data.Customizations.Find(drink.CustomizationId);
            }
            return View(orders);
        }

        [HttpPost]
        public IActionResult RemoveDrink(int id)
        {
            DrinkOrder order = data.DrinkOrders.Find(id);
            order.Active = false;
            data.Update(order);
            data.SaveChanges();
            IEnumerable<DrinkOrder> orders = data.DrinkOrders.Where(o => o.Active == true);
            foreach (DrinkOrder drink in orders)
            {
                drink.OrderedDrink = data.Drinks.Find(drink.DrinkId);
                drink.Customization = data.Customizations.Find(drink.CustomizationId);
            }
            return View("GetOrders", orders);

        }
    }
}
