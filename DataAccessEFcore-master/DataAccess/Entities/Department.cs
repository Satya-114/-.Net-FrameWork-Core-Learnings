namespace DataAccess.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Practice> Practices { get; set; }
        public ICollection<DepartmentProject> DepartmentProjects { get; set; }
    }
}
