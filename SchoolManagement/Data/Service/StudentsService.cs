using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolManagement.Data.Models;
using SchoolManagement.Data.ViewModels;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;

namespace SchoolManagement.Data.Service
{
    public class StudentsService
    {
        private AppDbContext _context;

        public StudentsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddStudentWithScores(StudentVM student)
        {
            var _student = new Student()
            {
                RollNo = student.RollNo,
                Name = student.Name,
                Section = student.Section,
                DOB = student.DOB,
                Age = student.Age,
                AcademicYear = student.AcademicYear,
                SportsInvolvement = student.SportsInvolvement,
                StandardId= student.StandardId
            };
            _context.students.Add(_student);
            _context.SaveChanges();

            foreach(var id in student.ScoreIds)
            {
                var _student_score = new Student_Score()
                {
                    StudentId = _student.Id,
                    ScoreId = id

                };
                _context.Students_Scores.Add(_student_score);
                _context.SaveChanges();
          }
        }

        public List<StudentWithScoresVM> GetAllStudents()
        {
            var _allStudents = _context.students.Select(student => new StudentWithScoresVM()
            {
                RollNo = student.RollNo,
                Name = student.Name,
                Section = student.Section,
                DOB = student.DOB,
                Age = student.Age,
                AcademicYear = student.AcademicYear,
                SportsInvolvement = student.SportsInvolvement,
                StandardName = student.Standard.StandardName,
                Percentage = student.Student_Scores.Select(n => n.Score.Percentage).ToList()
            }).ToList();
            return _allStudents;
        }

        public StudentWithScoresVM GetStudentById(int studentId)
        {
            var _studentWithScores = _context.students.Where(n => n.Id == studentId).Select(student => new StudentWithScoresVM()
            {
                RollNo = student.RollNo,
                Name = student.Name,
                Section = student.Section,
                DOB = student.DOB,
                Age = student.Age,
                AcademicYear = student.AcademicYear,
                SportsInvolvement = student.SportsInvolvement,
                StandardName = student.Standard.StandardName,
                Percentage = student.Student_Scores.Select(n => n.Score.Percentage).ToList()

            }).FirstOrDefault();

            return _studentWithScores;
        }

        public Student UpdateStudentById(int studentId,StudentVM student)
        {
            var _student=_context.students.FirstOrDefault(n=>n.Id==studentId);
            if( _student!=null )
            {
                _student.RollNo = student.RollNo;
                _student.Name = student.Name;
                _student.Section = student.Section;
                _student.DOB = student.DOB;
                _student.Age = student.Age;
                _student.AcademicYear = student.AcademicYear;
                _student.SportsInvolvement = student.SportsInvolvement;

                _context.SaveChanges();
            }
            return _student;
        }

        public void DeleteStudentById(int studentId)
        {
            var _student= _context.students.FirstOrDefault(n=>n.Id==studentId);
            if( _student!=null )
            {
                _context.students.Remove( _student );
                _context.SaveChanges();
            }

        }
        
    }
}
