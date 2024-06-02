namespace Web_API2.Service.EmployerService
{
    public interface IEmployerService
    {
        Task<ServiceResponse<List<GetEmployerDto>>> GetAllEmployers();
        Task<ServiceResponse<GetEmployerDto>> GetEmployerById(int id);
        Task<ServiceResponse<List<GetEmployerDto>>> AddEmployers(AddEmployerDto newEmployer);
        Task<ServiceResponse<GetEmployerDto>> UpdateEmployers(UpdateEmployerDto updateEmployer);
        Task<ServiceResponse<List<GetEmployerDto>>> DeleteEmployer(int id);
    }
}
