using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cafe_POS_Application.Models
{
    public class DbContextModel : DbContext
    {
        public DbContextModel(DbContextOptions<DbContextModel> options)
            : base(options)
        {
        }
        public DbContextModel() { }

        public DbSet<Tables> Table { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TransactionLog> Transactions { get; set; }
        public DbSet<PaymentLine> PaymentsLine { get; set; } 
    }
}
