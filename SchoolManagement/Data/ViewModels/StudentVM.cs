namespace SchoolManagement.Data.ViewModels
{
    public class StudentVM
    {
        public int RollNo { get; set; }

        public string Name { get; set; }

        public string Section { get; set; }
        public DateTime? DOB { get; set; }
        public int Age { get; set; }
        public string AcademicYear { get; set; }
        public string SportsInvolvement { get; set; }

        public int StandardId { get; set; }
        public List<int> ScoreIds { get; set; }
    }

    public class StudentWithScoresVM
    {
        public int RollNo { get; set; }

        public string Name { get; set; }

        public string Section { get; set; }
        public DateTime? DOB { get; set; }
        public int Age { get; set; }
        public string AcademicYear { get; set; }
        public string SportsInvolvement { get; set; }

        public string StandardName { get; set; }
        public List<int> Percentage { get; set; }
    }
}

