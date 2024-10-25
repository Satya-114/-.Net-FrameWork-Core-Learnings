using DependencyInjectionsample.Models;

public interface IEmployeeDAL
{
    void AddEmployee(Employee employee);
    List<Employee> GetAllEmployees();
    Employee GetEmployeeById(int id);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(int id);
}
