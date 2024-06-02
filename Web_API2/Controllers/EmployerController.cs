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
        public async Task<ActionResult<ServiceResponse<List<Employer>>>> Get()
        {
            var employer = _employerService.GetAllEmployers();
            return Ok(await employer);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Employer>>> GetSingle(int id)
        {
            var employer = _employerService.GetEmployerById(id);
            return Ok(await employer);

        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Employer>>>> AddEmployer(Employer newEmployer)
        {
            var employer = _employerService.AddEmployers(newEmployer);
            return Ok(await employer);
        }
    }
}
