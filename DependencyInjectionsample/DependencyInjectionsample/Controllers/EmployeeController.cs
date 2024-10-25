using Microsoft.AspNetCore.Mvc;

public class EmployeeController : Controller
{
    private readonly EmployeeBL _employeeBL;

    public EmployeeController(EmployeeBL employeeBL)
    {
        _employeeBL = employeeBL;
    }

    public IActionResult Index()
    {
        var employees = _employeeBL.GetAllEmployees();
        return View(employees);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(string name, string position, decimal salary)
    {
        _employeeBL.AddEmployee(name, position, salary);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var employee = _employeeBL.GetEmployeeById(id);
        return View(employee);
    }

    [HttpPost]
    public IActionResult Edit(int id, string name, string position, decimal salary)
    {
        _employeeBL.UpdateEmployee(id, name, position, salary);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _employeeBL.DeleteEmployee(id);
        return RedirectToAction("Index");
    }
}
