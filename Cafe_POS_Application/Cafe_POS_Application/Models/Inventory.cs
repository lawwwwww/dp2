using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_POS_Application.Models
{
    public class Inventory
    {
        [Key]
        [MaxLength(30)]
        public string FoodCode { get; set; }
        public string DishName { get; set; }
        public string Drinks { get; set; }
        public int Quantity { get; set; }
    }
}
