using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_POS_Application.Models
{
    public class Tables
    {
        [Key]
        [MaxLength(30)]
        public int TableNo { get; set; }
        public string Status { get; set; }
        public string Reservation { get; set; }
        public DateTime ReservationDate { get; set; }

        public List<TransactionLog> TransactionLog { get; set; }
    }
}

