namespace Web_API2.Service.EmployerService
{
    public class EmployerService : IEmployerService
    {
        private static List<Employer> employers = new List<Employer>
        {
            new Employer(),
            new Employer{Id = 1, NameOfCompany = "google"}
        };


        public List<Employer> AddEmployers(Employer newEmployer)
        {
            employers.Add(newEmployer);
            return employers;
        }

        public List<Employer> GetAllEmployers()
        {
            return employers;
        }

        public Employer GetEmployerById(int id)
        {
            return employers.FirstOrDefault(c => c.Id == id);
        }
    }
}
