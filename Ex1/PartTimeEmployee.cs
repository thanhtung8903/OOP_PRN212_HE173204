using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_PRN212
{
    public class PartTimeEmployee : Employee
    {
        public int WorkingHours { get; set; }

        public PartTimeEmployee(string name, int paymentPerHour, int workingHours)
            : base(name, paymentPerHour)
        {
            WorkingHours = workingHours;
        }

        public override int CalculateSalary()
        {
            return WorkingHours * PaymentPerHour;
        }

        public override string ToString()
        {
            return base.ToString() + $", Working Hours: {WorkingHours}, Salary: {CalculateSalary()}";
        }
    }

}
