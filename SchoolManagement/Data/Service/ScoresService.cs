using SchoolManagement.Data.Models;
using SchoolManagement.Data.ViewModels;

namespace SchoolManagement.Data.Service
{
    public class ScoresService
    {
        private AppDbContext _context;

        public ScoresService(AppDbContext context)
        {
            _context = context;
        }

        public void AddScore(ScoreVM score)
        {
            var _score = new Score()
            {
                Percentage = score.Percentage,
            };
            _context.Scores.Add(_score);
            _context.SaveChanges();
        }

        public ScoreWithStudentsVM GetScoreWithStudents(int scoreId)
        {
            var _score=_context.Scores.Where(n=>n.Id == scoreId).Select(n=>new ScoreWithStudentsVM()
            {
                Percentage=n.Percentage,
                StudentNames=n.Student_Scores.Select(n=>n.Student.Name).ToList()
            }).FirstOrDefault();
            return _score;
        }
    }
}
