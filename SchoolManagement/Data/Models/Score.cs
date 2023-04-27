namespace SchoolManagement.Data.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int Percentage { get;set; }

        public List<Student_Score> Student_Scores { get; set; }
    }
}
