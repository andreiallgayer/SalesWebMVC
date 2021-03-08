using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birth, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            Birth = birth;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord x)
        {
            Sales.Add(x);
        }

        public void RemoveSales(SalesRecord x)
        {
            Sales.Remove(x);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sales => (sales.Date >= initial && sales.Date <= final)).Sum(total => (total.Amount));
        }
    }
}