using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_POS_Application.Models
{
    public class TransactionLog
    {
        [Key]
        [MaxLength(30)]
        public Guid TransactionID { get; set; }
        public int OrderNo { get; set; }
        public string OrderDetails { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DateTime { get; set; }

        public int TableNo { get; set; }
        public Tables Tables { get; set; }
        public string EmpName { get; set; }
        public Employee Employee { get; set; }
    }
}



