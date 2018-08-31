using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarTender.Models
{
    public class BartenderDBContext : DbContext
    {
        public BartenderDBContext(DbContextOptions<BartenderDBContext> options)
                : base(options)
        {
        }

        public DbSet<DrinkOrder> DrinkOrders { get; set; }
        public DbSet<Customization> Customizations { get; set; }
        public DbSet<Drink> Drinks { get; set; }
    }
}
