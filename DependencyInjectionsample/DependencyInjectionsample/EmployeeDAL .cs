using DependencyInjectionsample.Models;
using System.Collections.Generic;

public class EmployeeDAL : IEmployeeDAL
{
    private readonly List<Employee> _employees = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        _employees.Add(employee);
    }

    public List<Employee> GetAllEmployees()
    {
        return _employees;
    }

    public Employee GetEmployeeById(int id)
    {
        return _employees.Find(emp => emp.Id == id);
    }

    public void UpdateEmployee(Employee employee)
    {
        var existingEmployee = GetEmployeeById(employee.Id);
        if (existingEmployee != null)
        {
            existingEmployee.Name = employee.Name;
            existingEmployee.Position = employee.Position;
            existingEmployee.Salary = employee.Salary;
        }
    }

    public void DeleteEmployee(int id)
    {
        var employee = GetEmployeeById(id);
        if (employee != null)
        {
            _employees.Remove(employee);
        }
    }
}
