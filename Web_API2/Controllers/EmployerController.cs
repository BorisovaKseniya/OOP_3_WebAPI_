global using Web_API2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_API2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployerController : ControllerBase
    {

        private readonly IEmployerService _employerService;
        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployerDto>>>> Get()
        {
            var employer = _employerService.GetAllEmployers();
            return Ok(await employer);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployerDto>>> GetSingle(int id)
        {
            var employer = _employerService.GetEmployerById(id);
            return Ok(await employer);

        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetEmployerDto>>>> AddEmployer(AddEmployerDto newEmployer)
        {
            var employer = _employerService.AddEmployers(newEmployer);
            return Ok(await employer);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetEmployerDto>>> UpdateEmployer(UpdateEmployerDto updateEmployer)
        {
            var response = await _employerService.UpdateEmployers(updateEmployer);
            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployerDto>>> DeleteEmployer(int id)
        {
            var response = await _employerService.DeleteEmployer(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}

