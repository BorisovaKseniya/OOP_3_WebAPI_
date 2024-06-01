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
        public ActionResult<List<Employer>> Get()
        {
            var employer = _employerService.GetAllEmployers();
            return Ok(employer);
        }

        [HttpGet("{id}")]
        public ActionResult<List<Employer>> GetSingle(int id)
        {
            var employer = _employerService.GetEmployerById(id);
            if (employer != null)
                return Ok(employer);
            else
                throw new Exception("Employer not found");
        }
        [HttpPost]
        public ActionResult<List<Employer>> AddEmployer(Employer newEmployer)
        {
            var employer = _employerService.AddEmployers(newEmployer);
            return Ok(employer);
        }
    }
}
