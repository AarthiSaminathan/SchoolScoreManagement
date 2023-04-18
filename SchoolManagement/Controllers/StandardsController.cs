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
    public class StandardsController : ControllerBase
    {
        private StandardsService _standardsService;
        public StandardsController(StandardsService standardsService)
        {
            _standardsService = standardsService;
        }


        [HttpPost("add-standard")]
        public IActionResult AddStandard(StandardVM standard)
        {
            Log.Information("Inside controller:StandardsController");

            _standardsService.AddStandard(standard);
            Log.Information($"The response for the post school management is{JsonConvert.SerializeObject(standard)}");

            return Ok();
        }

        [HttpGet("get-standard-student-with-scores/{id}")]
        public IActionResult GetStandardData(int id)
        {
            Log.Information("Inside controller:StandardsController");

            var _response = _standardsService.GetStandardData(id);
            Log.Information($"The response for the getstandardbyid school management is{JsonConvert.SerializeObject(id)}");

            return Ok(_response);
        }

        [HttpDelete("delete-standard-by-id/{id}")]
        public IActionResult DeleteStandardById(int id)
        {
            Log.Information("Inside controller:StandardsController");

            _standardsService.DeleteStandardById(id);
            Log.Information($"The response for the delete school management is{JsonConvert.SerializeObject(id)}");

            return Ok();
        }

    }
}
