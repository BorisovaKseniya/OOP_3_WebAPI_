namespace Web_API2.Service.EmployerService
{
    public class EmployerService : IEmployerService
    {
        private static List<Employer> employers = new List<Employer>
        {
            new Employer(),
            new Employer{Id = 1, NameOfCompany = "google"}
        };


        public async Task<ServiceResponse<List<Employer>>> AddEmployers(Employer newEmployer)
        {
            var serviceResponse = new ServiceResponse<List<Employer>>();
            employers.Add(newEmployer);
            serviceResponse.Data = employers;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Employer>>> GetAllEmployers()
        {
            var serviceResponse = new ServiceResponse<List<Employer>>();
            serviceResponse.Data = employers;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Employer>> GetEmployerById(int id)
        {
            var serviceResponse = new ServiceResponse<Employer>();
            var employer = employers.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = employer;
            return serviceResponse;
        }
    }
}
