namespace DataAccess.Entities
{
    public class DepartmentProject
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
