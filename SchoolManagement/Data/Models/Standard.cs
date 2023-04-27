namespace SchoolManagement.Data.Models
{
    public class Standard
    {
        public int Id { get; set; }
        public string StandardName { get; set; }

        public List<Student> Students { get; set; }
    }
}
