namespace OOP_PRN212
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add employee");
                Console.WriteLine("2. Find highest salary employee");
                Console.WriteLine("3. Find employee by name");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee(employees);
                        break;
                    case 2:
                        FindHighestSalaryEmployee(employees);
                        break;
                    case 3:
                        FindEmployeeByName(employees);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }

        static void AddEmployee(List<Employee> employees)
        {
            try
            {
                Console.Write("Enter employee's name: ");
                string name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Name not be empty");
                }

                Console.Write("Enter payment per hour: ");
                int paymentPerHour = int.Parse(Console.ReadLine());

                if (paymentPerHour <= 0)
                {
                    throw new ArgumentException("Must be greater than 0.");
                }

                Console.WriteLine("Enter type employee");
                Console.WriteLine("1. Fulltime");
                Console.WriteLine("2. Partime");
                int type = int.Parse(Console.ReadLine());

                if (type == 1)
                {
                    employees.Add(new FullTimeEmployee(name, paymentPerHour));
                }
                else if (type == 2)
                {
                    Console.Write("Enter hour: ");
                    int workingHours = int.Parse(Console.ReadLine());
                    employees.Add(new PartTimeEmployee(name, paymentPerHour, workingHours));
                }
                else
                {
                    Console.WriteLine("Employee invalid.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void FindHighestSalaryEmployee(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("List employee empty");
                return;
            }

            Employee highestSalaryEmployee = null;
            int highestSalary = 0;

            foreach (var employee in employees)
            {
                int salary = employee.CalculateSalary();
                if (salary > highestSalary)
                {
                    highestSalary = salary;
                    highestSalaryEmployee = employee;
                }
            }

            if (highestSalaryEmployee != null)
            {
                Console.WriteLine("Highest salary employee: ");
                Console.WriteLine(highestSalaryEmployee);
            }
        }

        static void FindEmployeeByName(List<Employee> employees)
        {
            Console.Write("Enter name to find ");
            string name = Console.ReadLine();
            var foundEmployees = employees.FindAll(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (foundEmployees.Count > 0)
            {
                Console.WriteLine("List employee find by name:" + name);
                foreach (var employee in foundEmployees)
                {
                    Console.WriteLine(employee);
                }
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
    }

}
