using DependencyInjectionsample.Models;
using System;
using System.Collections.Generic;

public class EmployeeBL
{
    private readonly IEmployeeDAL _employeeDAL;

    public EmployeeBL(IEmployeeDAL employeeDAL)
    {
        _employeeDAL = employeeDAL;
    }

    public void AddEmployee(string name, string position, decimal salary)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(position) || salary <= 0)
        {
            throw new ArgumentException("Invalid employee details");
        }

        int id = new Random().Next(1, 1000); // For demo purposes
        var employee = new Employee(id, name, position, salary);
        _employeeDAL.AddEmployee(employee);
    }

    public List<Employee> GetAllEmployees()
    {
        return _employeeDAL.GetAllEmployees();
    }

    public Employee GetEmployeeById(int id)
    {
        return _employeeDAL.GetEmployeeById(id);
    }

    public void UpdateEmployee(int id, string name, string position, decimal salary)
    {
        var employee = new Employee(id, name, position, salary);
        _employeeDAL.UpdateEmployee(employee);
    }

    public void DeleteEmployee(int id)
    {
        _employeeDAL.DeleteEmployee(id);
    }
}
