namespace DataAccess.Entities
{
    public class Practice
    {
        public int PracticeId { get; set; }
        public string PracticeName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
