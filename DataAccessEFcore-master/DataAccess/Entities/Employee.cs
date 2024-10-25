namespace DataAccess.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int PracticeId { get; set; }
        public Practice Practice { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
