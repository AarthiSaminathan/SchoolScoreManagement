using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolManagement.Data.Models;
using SchoolManagement.Data.Service;
using SchoolManagement.Data.ViewModels;
using Serilog;
using System.Security.Policy;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public StudentsService _studentsService;

        public StudentsController(StudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpPost("add-student-with-scores")]
        
        public IActionResult AddStudent(StudentVM student)
        {
            Log.Information("Inside controller:StudentsController");

            _studentsService.AddStudentWithScores(student);

            Log.Information($"The response for the post school management is{JsonConvert.SerializeObject(student)}");
            return Ok();
        }

        [HttpGet("get-all-students")]
        public IActionResult GetAllStudents()
        {
            Log.Information("Inside controller:StudentsController");

            var allStudents =_studentsService.GetAllStudents();
            Log.Information($"The response for the getallstudents school management is{JsonConvert.SerializeObject(allStudents)}");

            return Ok(allStudents);
        }

        [HttpGet("get-all-students-by-id/{id}")]
        public IActionResult GetStudentById(int id)
        {
            Log.Information("Inside controller:StudentsController");

            var student = _studentsService.GetStudentById( id);
            Log.Information($"The response for the getstudentbyid school management is{JsonConvert.SerializeObject(student)}");

            return Ok(student);
        }

        [HttpPut("update-student-by-id/{id}")]
        public IActionResult UpdateStudentById(int id,StudentVM student)
        {
            Log.Information("Inside controller:StudentsController");

            var upadateStudent =_studentsService.UpdateStudentById(id,student);
            Log.Information($"The response for the get school management is{JsonConvert.SerializeObject(upadateStudent)}");

            return Ok(upadateStudent);
        }

        [HttpDelete("delete-student-by-id/{id}")]
        public IActionResult DeleteStudentById(int id)
        {
            Log.Information("Inside controller:StudentsController");

            _studentsService.DeleteStudentById(id);
            Log.Information($"The response for the get school management is{JsonConvert.SerializeObject(id)}");

            return Ok();
        }
    }
}
