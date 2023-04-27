using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolManagement.Data.Models;
using SchoolManagement.Data.Service;
using SchoolManagement.Data.ViewModels;
using Serilog;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private ScoresService _scoresService;
        public ScoresController(ScoresService scoresService)
        {
            _scoresService = scoresService;
        }


        [HttpPost("add-score")]
        public IActionResult AddScore(ScoreVM score)
        {
            Log.Information("Inside controller:ScoresController");

            _scoresService.AddScore(score);
            Log.Information($"The response for the post school management is{JsonConvert.SerializeObject(score)}");

            return Ok();
        }

        [HttpGet("get-score-with-students")]
        public IActionResult GetScoreWithStudents(int id)
        {
            Log.Information("Inside controller:ScoresController");

            var response =_scoresService.GetScoreWithStudents(id);
            Log.Information($"The response for the getallscore school management is{JsonConvert.SerializeObject(id)}");

            return Ok(response);

        }
    }
}
