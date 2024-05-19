namespace Ex2
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<Customer> customers = new List<Customer>();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Employee or Customer");
                Console.WriteLine("2. Find Employee with Highest Salary and Customer with Lowest Balance");
                Console.WriteLine("3. Find Employee by Name");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddPerson(employees, customers);
                        break;
                    case 2:
                        FindHighestSalaryEmployeeAndLowestBalanceCustomer(employees, customers);
                        break;
                    case 3:
                        FindEmployeeByName(employees);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddPerson(List<Employee> employees, List<Customer> customers)
        {
            try
            {
                Console.WriteLine("Select type of person:");
                Console.WriteLine("1. Employee");
                Console.WriteLine("2. Customer");
                int type = int.Parse(Console.ReadLine());

                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                Console.Write("Enter address: ");
                string address = Console.ReadLine();

                if (string.IsNullOrEmpty(address))
                {
                    throw new ArgumentException("Address cannot be empty.");
                }

                if (type == 1)
                {
                    Console.Write("Enter salary: ");
                    int salary = int.Parse(Console.ReadLine());

                    if (salary <= 0)
                    {
                        throw new ArgumentException("Salary must be greater than 0.");
                    }

                    employees.Add(new Employee(name, address, salary));
                }
                else if (type == 2)
                {
                    Console.Write("Enter balance: ");
                    int balance = int.Parse(Console.ReadLine());

                    if (balance < 0)
                    {
                        throw new ArgumentException("Balance must be non-negative.");
                    }

                    customers.Add(new Customer(name, address, balance));
                }
                else
                {
                    Console.WriteLine("Invalid person type.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void FindHighestSalaryEmployeeAndLowestBalanceCustomer(List<Employee> employees, List<Customer> customers)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
            }
            else
            {
                Employee highestSalaryEmployee = null;
                int highestSalary = 0;

                foreach (var employee in employees)
                {
                    if (employee.Salary > highestSalary)
                    {
                        highestSalary = employee.Salary;
                        highestSalaryEmployee = employee;
                    }
                }

                if (highestSalaryEmployee != null)
                {
                    Console.WriteLine("Employee with the highest salary:");
                    highestSalaryEmployee.Display();
                }
            }

            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found.");
            }
            else
            {
                Customer lowestBalanceCustomer = null;
                int lowestBalance = int.MaxValue;

                foreach (var customer in customers)
                {
                    if (customer.Balance < lowestBalance)
                    {
                        lowestBalance = customer.Balance;
                        lowestBalanceCustomer = customer;
                    }
                }

                if (lowestBalanceCustomer != null)
                {
                    Console.WriteLine("Customer with the lowest balance:");
                    lowestBalanceCustomer.Display();
                }
            }
        }

        static void FindEmployeeByName(List<Employee> employees)
        {
            Console.Write("Enter the name of the employee to find: ");
            string name = Console.ReadLine();
            var foundEmployees = employees.FindAll(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (foundEmployees.Count > 0)
            {
                Console.WriteLine("Employees found:");
                foreach (var employee in foundEmployees)
                {
                    employee.Display();
                }
            }
            else
            {
                Console.WriteLine("No employees found with that name.");
            }
        }
    }

}
