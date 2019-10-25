using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_POS_Application.Models
{
    public class Order
    {
        /*public Order(DbContextModel db,int OrderNo,string EmpName,string FoodCode,string Size,int Quantity,DateTime DateTime,int TableNo)
        {

            this.OrderNo = OrderNo;
            this.EmpName = EmpName;
            this.FoodCode = FoodCode;
            this.Size = Size;
            this.Quantity = Quantity;
            this.DateTime = DateTime;
            this.TableNo = TableNo;
        }*/

        [Key]
        [MaxLength(30)]
        public int OrderNo { get; set; }
        [Required]
        public string EmpName { get; set; }
        public int FoodCode { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public DateTime DateTime { get; set; }
        public int TableNo { get; set; }


    }
}
