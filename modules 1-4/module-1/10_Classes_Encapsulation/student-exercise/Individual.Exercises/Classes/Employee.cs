namespace Individual.Exercises.Classes
{
    public class Employee
    {
        public Employee(int employeeID, string firstName, string lastName, double salary)
        {
            EmployeeId = employeeID;
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = salary;
        }

        //properties
        public int EmployeeId
        {
            get;
        }

        public string FirstName
        {
            get;
        }

        public string LastName
        {
            get; set;
        }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;

            }
        }

        public double AnnualSalary
        {
            get; private set;
        }

        public string Department
        {
            get; set;
        }

        public void RaiseSalary(double percent)
        {
            AnnualSalary = AnnualSalary + (AnnualSalary *(percent / 100));
        }
    }
}

