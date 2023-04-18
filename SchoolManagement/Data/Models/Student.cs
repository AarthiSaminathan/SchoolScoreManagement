using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public int RollNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Section { get; set; }
        public DateTime? DOB { get; set; }
        public int Age { get; set; }
        public string AcademicYear { get; set; }
        public string SportsInvolvement { get; set; }

        public int StandardId { get; set; }
        public Standard Standard { get; set; }

        public List<Student_Score> Student_Scores { get; set; }


    }
}
