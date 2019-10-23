using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_POS_Application.Models
{
    public class Employee
    {
        [Key]
        [MaxLength(30)]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime HireDate { get; set; }

        public List<TransactionLog> TransactionLog { get; set; }
    }
}
