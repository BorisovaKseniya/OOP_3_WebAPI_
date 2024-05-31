namespace Web_API2.Service.EmployerService
{
    public interface IEmployerService
    {
        List<Employer> GetAllEmployers();
        Employer GetEmployerById(int id);
        List<Employer> AddEmployers(Employer newEmployer);
    }
}
