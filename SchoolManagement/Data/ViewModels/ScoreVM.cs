namespace SchoolManagement.Data.ViewModels
{
    public class ScoreVM
    {
        public int Percentage { get; set; }

    }

    public class ScoreWithStudentsVM
    {
        public int Percentage { get; set; }
        public List<string> StudentNames { get; set; }
    }
}
