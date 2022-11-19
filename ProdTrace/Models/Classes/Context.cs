using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProdTrace.Models.Classes
{
    public class Context: DbContext  //Burası üzerinden tablolarımı sql'e yazdıracağım.
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Outlay> Outlays { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceColumn> InvoiceColumns { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesMovement> SalesMovements { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        
    }
}