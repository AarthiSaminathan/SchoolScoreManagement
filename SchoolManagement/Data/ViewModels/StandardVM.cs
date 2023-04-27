namespace SchoolManagement.Data.ViewModels
{
    public class StandardVM
    {
        public string StandardName { get; set; }

    }

    public class StandardWithStudentsAndScoresVM
    {
        public string StandardName { get; set; }
        public List<StudentScoreVM> StudentScores { get; set; }

    }

    public class StudentScoreVM
    {
        public string StudentName { get; set; } 
        public List<int> StudentScores { get; set; }

    }
}
