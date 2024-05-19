using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_PRN212
{
    public abstract class Employee : IEmployee
    {
        public string Name { get; set; }
        public int PaymentPerHour { get; set; }

        public Employee(string name, int paymentPerHour)
        {
            Name = name;
            PaymentPerHour = paymentPerHour;
        }

        public abstract int CalculateSalary();

        public string GetName()
        {
            return Name;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Payment Per Hour: {PaymentPerHour}";
        }
    }
}
