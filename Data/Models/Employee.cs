namespace AngularDotNet.Data.Models
{
    public class Employee
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }
        public int DepartmentId { get; set; }
    }
}
