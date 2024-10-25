namespace DataAccess.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public ICollection<DepartmentProject> DepartmentProjects { get; set; }
    }
}
