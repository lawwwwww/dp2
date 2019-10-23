using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_POS_Application.Models
{
    public class Payment
    {
        [Key]
        [MaxLength(30)]
        public Guid TransactionID { get; set; }
        [Required]
        public int OrderNo { get; set; }
        public DateTime DateTime { get; set; }
        public string OrderDetails { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
        public virtual List<PaymentLine> PaymentLine { get; set; }=new List<PaymentLine>();
    }

    public class PaymentLine
    {
        public Guid TransactionLineId { get; set; }
        public Guid TransactionID { get; set; }
        public Payment Payment { get; set; }
        public Guid ID { get; set; }
        public Menu Menu { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }

    }
}
