using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // List all employees with their practice and department information
    public IActionResult Index()
    {
        var employees = _context.Employees
            .Include(e => e.Practice)
            .ThenInclude(p => p.Department)
            .Include(e => e.EmployeeProjects)
            .ThenInclude(ep => ep.Project)
            .ToList();

        return View(employees);
    }

    // Show details of a single employee, including their projects and practice details
    public IActionResult Details(int id)
    {
        var employee = _context.Employees
            .Include(e => e.Practice)
            .ThenInclude(p => p.Department)
            .Include(e => e.EmployeeProjects)
            .ThenInclude(ep => ep.Project)
            .FirstOrDefault(e => e.EmployeeId == id);

        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // Show form to create a new employee
    [HttpGet]
    public IActionResult Create()
    {
        ViewData["Practices"] = new SelectList(_context.Practices, "PracticeId", "PracticeName");
        ViewData["Projects"] = new SelectList(_context.Projects, "ProjectId", "ProjectName");
        return View();
    }

    // Handle form submission for creating a new employee
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Employee employee, int[] selectedProjects)
    {
        if (ModelState.IsValid)
        {
            foreach (var projectId in selectedProjects)
            {
                employee.EmployeeProjects.Add(new EmployeeProject
                {
                    ProjectId = projectId
                });
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewData["Practices"] = new SelectList(_context.Practices, "PracticeId", "PracticeName", employee.PracticeId);
        ViewData["Projects"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", selectedProjects);
        return View(employee);
    }

    // Show form to edit an existing employee
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var employee = _context.Employees
            .Include(e => e.EmployeeProjects)
            .FirstOrDefault(e => e.EmployeeId == id);

        if (employee == null)
        {
            return NotFound();
        }

        ViewData["Practices"] = new SelectList(_context.Practices, "PracticeId", "PracticeName", employee.PracticeId);
        ViewData["Projects"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", employee.EmployeeProjects.Select(ep => ep.ProjectId));
        return View(employee);
    }

    // Handle form submission for editing an existing employee
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Employee employee, int[] selectedProjects)
    {
        if (id != employee.EmployeeId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var existingEmployee = _context.Employees
                .Include(e => e.EmployeeProjects)
                .FirstOrDefault(e => e.EmployeeId == id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            // Update the employee's properties
            existingEmployee.Name = employee.Name;
            existingEmployee.Position = employee.Position;
            existingEmployee.PracticeId = employee.PracticeId;

            // Update the employee's projects
            existingEmployee.EmployeeProjects.Clear();
            foreach (var projectId in selectedProjects)
            {
                existingEmployee.EmployeeProjects.Add(new EmployeeProject
                {
                    EmployeeId = id,
                    ProjectId = projectId
                });
            }

            _context.Update(existingEmployee);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        ViewData["Practices"] = new SelectList(_context.Practices, "PracticeId", "PracticeName", employee.PracticeId);
        ViewData["Projects"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", selectedProjects);
        return View(employee);
    }

    // Delete an employee
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var employee = _context.Employees
            .Include(e => e.EmployeeProjects)
            .FirstOrDefault(e => e.EmployeeId == id);

        if (employee == null)
        {
            return NotFound();
        }

        _context.Employees.Remove(employee);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
