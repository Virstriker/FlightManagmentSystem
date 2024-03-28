using System;
using System.Collections.Generic;
using System.Collections;
// 1) AddNewEmployee( )
// 2) RemoveEmployeeWithId( )
// 3) RemoveEmployeewithGivenSalary( )
// 4) Provide employees with top n salaries
// 5) Provide employees with n lowest salaries
// 6) Provide all employees with the given salary range
// 7) GetEmployeeByMobileNumber( )
// 8) DisplayAllEmployeesByExperience( )
// 9) RemoveAllEmployeesWithCondition( ) 
namespace Employee;
class Program
{
    public static void Main(string[] args)
    {
        EmployeeManager manager = new EmployeeManager();
        Console.Write(" 1) AddNewEmployee \n 2) RemoveEmployeeWithId \n 3) RemoveEmployeewithGivenSalary \n 4)Provide employees with top n salaries \n 5)Provide employees with n lowest salaries \n 6)Provide all employees with the given salary range\n 7) GetEmployeeByMobileNumber \n 8)DisplayAllEmployeesByExperience \n 9) RemoveAllEmployeesWithCondition\n 10)Exit \n \n Enter your choice: ");
        while (true)
        {
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    manager.AddNewEmployee();
                    break;
                case 2:
                    manager.RemoveEmployeeWithId();
                    break;
                case 3:
                    manager.RemoveEmployeewithGivenSalary();
                    break;
                case 4:
                    manager.ProvideEmployeesWithTopNSalaries();
                    break;
                case 5:
                    manager.ProvideEmployeesWithNLowestSalaries();
                    break;
                case 6:
                    manager.ProvideEmployeesWithSalaryRange();
                    break;
                case 7:
                    manager.GetEmployeeByMobileNumber();
                    break;
                case 8:
                    manager.DisplayAllEmployeesByExperience();
                    break;
                case 9:
                    manager.RemoveAllEmployeesWithCondition();
                    break;
                default:
                    Console.WriteLine("Thank you for using our banking system");
                    return;
            }
        }
    }
}
class Employee
{
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public DateOnly EmployeeDateOfBirth { get; set; }
    public int EmployeeMobileNo { get; set; }
    public int Experiance { get; set; }
    public int Salary { get; set; }
}
class EmployeeManager
{
    SortedSet<Employee> EmpSet;
    public EmployeeManager()
    {
        EmpSet = new SortedSet<Employee>(new SortBySalary());
    }
    public void AddNewEmployee()
    {
        Console.WriteLine("Enter Employee ID: ");
        int empId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Employee Name: ");
        string empName = Console.ReadLine();
        Console.WriteLine("Enter Employee Date of Birth(yyyy/mm/dd): ");
        string date = Console.ReadLine();
        DateOnly empDateOfBirth = DateOnly.Parse(date);
        Console.WriteLine("Enter Employee Mobile No: ");
        int empMobileNo = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Employee Experiance: ");
        int empExperiance = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Employee Salary: ");
        int empSalary = Convert.ToInt32(Console.ReadLine());
        EmpSet.Add(new Employee { EmployeeID = empId, EmployeeName = empName, EmployeeDateOfBirth = empDateOfBirth, EmployeeMobileNo = empMobileNo, Experiance = empExperiance, Salary = empSalary });
    }
    public void RemoveEmployeeWithId()
    {
        Console.WriteLine("Enter Employee ID: ");
        int empId = Convert.ToInt32(Console.ReadLine());
        EmpSet.RemoveWhere(x => x.EmployeeID == empId);
    }
    public void RemoveEmployeewithGivenSalary()
    {
        Console.WriteLine("Enter Employee Salary: ");
        int empSalary = Convert.ToInt32(Console.ReadLine());
        EmpSet.RemoveWhere(x => x.Salary == empSalary);
    }
    public void ProvideEmployeesWithTopNSalaries()
    {
        Console.WriteLine("Enter n: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int a = 0;
        foreach (Employee emp in EmpSet)
        {
            if (a == n)
            {
                a++;
                break;
            }
            Console.WriteLine("Employee ID: {0} \n Employee Name: {1} \n Employee Date of Birth: {2} \n Employee Mobile No: {3} \n Employee Experiance: {4} \n Employee Salary: {5} \n", emp.EmployeeID, emp.EmployeeName, emp.EmployeeDateOfBirth, emp.EmployeeMobileNo, emp.Experiance, emp.Salary);
        }
    }
    public void ProvideEmployeesWithNLowestSalaries()
    {
        Console.WriteLine("Enter n: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int a = EmpSet.Count;
        int b = 0;
        int c = a - n;
        foreach (Employee emp in EmpSet)
        {
            if (b >= c)
            {
                Console.WriteLine("Employee ID: {0} \n Employee Name: {1} \n Employee Date of Birth: {2} \n Employee Mobile No: {3} \n Employee Experiance: {4} \n Employee Salary: {5} \n", emp.EmployeeID, emp.EmployeeName, emp.EmployeeDateOfBirth, emp.EmployeeMobileNo, emp.Experiance, emp.Salary);
                b++;
            }
            else
            {
                b++;
            }
        }
    }
    public void ProvideEmployeesWithSalaryRange()
    {
        Console.WriteLine("Enter salary range FROM: ");
        int salaryRangeFrom = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter salary range To: ");
        int salaryRangeTo = Convert.ToInt32(Console.ReadLine());
        foreach (Employee emp in EmpSet)
        {
            if (emp.Salary >= salaryRangeFrom && emp.Salary <= salaryRangeTo)
            {
                Console.WriteLine("Employee ID: {0} \n Employee Name: {1} \n Employee Date of Birth: {2} \n Employee Mobile No: {3} \n Employee Experiance: {4} \n Employee Salary: {5} \n", emp.EmployeeID, emp.EmployeeName, emp.EmployeeDateOfBirth, emp.EmployeeMobileNo, emp.Experiance, emp.Salary);
            }
        }
    }
    public void GetEmployeeByMobileNumber()
    {
        Console.WriteLine("Enter Employee Mobile No: ");
        int empMobileNo = Convert.ToInt32(Console.ReadLine());
        foreach (Employee emp in EmpSet)
        {
            if (emp.EmployeeMobileNo == empMobileNo)
            {
                Console.WriteLine("Employee ID: {0} \n Employee Name: {1} \n Employee Date of Birth: {2} \n Employee Mobile No: {3} \n Employee Experiance: {4} \n Employee Salary: {5} \n", emp.EmployeeID, emp.EmployeeName, emp.EmployeeDateOfBirth, emp.EmployeeMobileNo, emp.Experiance, emp.Salary);
            }
        }
    }
    public void DisplayAllEmployeesByExperience()
    {
        Console.WriteLine("Enter Employee Experiance: ");
        int empExperiance = Convert.ToInt32(Console.ReadLine());
        foreach (Employee emp in EmpSet)
        {
            if (emp.Experiance == empExperiance)
            {
                Console.WriteLine("Employee ID: {0} \n Employee Name: {1} \n Employee Date of Birth: {2} \n Employee Mobile No: {3} \n Employee Experiance: {4} \n Employee Salary: {5} \n", emp.EmployeeID, emp.EmployeeName, emp.EmployeeDateOfBirth, emp.EmployeeMobileNo, emp.Experiance, emp.Salary);
            }
        }
    }
    public void RemoveAllEmployeesWithCondition()
    {
        Console.WriteLine("Enter Employee Experiance: ");
        int empExperiance = Convert.ToInt32(Console.ReadLine());
        EmpSet.RemoveWhere(x => x.Experiance < empExperiance);
    }

}
class SortBySalary : IComparer<Employee>
{
    public int Compare(Employee e1, Employee e2)
    {
        return e2.Salary.CompareTo(e1.Salary);
    }
}
class SortByExperience : IComparer<Employee>
{

}