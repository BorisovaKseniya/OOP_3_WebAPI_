namespace Web_API2.Service.EmployerService
{
    public interface IEmployerService
    {
        Task<ServiceResponse<List<Employer>>> GetAllEmployers();
        Task<ServiceResponse<Employer>> GetEmployerById(int id);
        Task<ServiceResponse<List<Employer>>> AddEmployers(Employer newEmployer);
    }
}
