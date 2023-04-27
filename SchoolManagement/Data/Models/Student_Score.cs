namespace SchoolManagement.Data.Models
{
    public class Student_Score
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ScoreId { get; set; }
        public Score Score { get; set; }

    }
}
