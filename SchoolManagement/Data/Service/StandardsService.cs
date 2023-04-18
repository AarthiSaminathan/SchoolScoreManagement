using SchoolManagement.Data.Models;
using SchoolManagement.Data.ViewModels;

namespace SchoolManagement.Data.Service
{
    public class StandardsService
    {
        private AppDbContext _context;

        public StandardsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddStandard(StandardVM publisher)
        {
            var _standard = new Standard()
            {
                StandardName=publisher.StandardName,
            };
            _context.Standards.Add(_standard);
            _context.SaveChanges();
        }

        public StandardWithStudentsAndScoresVM GetStandardData(int standardId)
        {
            var _standardData = _context.Standards.Where(n => n.Id == standardId).Select(n => new StandardWithStudentsAndScoresVM()
            {
                StandardName = n.StandardName,
                StudentScores = n.Students.Select(n => new StudentScoreVM()
                {
                    StudentName = n.Name,
                    StudentScores = n.Student_Scores.Select(n => n.Score.Percentage).ToList()
                }).ToList()

            }).FirstOrDefault();

            return _standardData;
        }

        internal void DeleteStandardById(int id)
        {
            var _standard=_context.Standards.FirstOrDefault(n=>n.Id == id);
            if( _standard!=null )
            {
                _context.Standards.Remove(_standard);
                _context.SaveChanges();
            }

        }
    }
}
