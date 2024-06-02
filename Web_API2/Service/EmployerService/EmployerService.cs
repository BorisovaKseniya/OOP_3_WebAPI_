namespace Web_API2.Service.EmployerService
{
    public class EmployerService : IEmployerService
    {
        private static List<Employer> employers = new List<Employer>
        {
            new Employer(),
            new Employer{Id = 1, NameOfCompany = "google"}
        };

        private readonly IMapper _mapper;
        public EmployerService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<GetEmployerDto>>> AddEmployers(AddEmployerDto newEmployer)
        {
            var serviceResponse = new ServiceResponse<List<GetEmployerDto>>();
            var employer = _mapper.Map<Employer>(newEmployer);
            employer.Id = employers.Max(c => c.Id) + 1;
            employers.Add(employer);
            serviceResponse.Data = employers.Select(c => _mapper.Map<GetEmployerDto>(c)).ToList(); // почитать про лямбда-выражения
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetEmployerDto>>> GetAllEmployers()
        {
            var serviceResponse = new ServiceResponse<List<GetEmployerDto>>();
            serviceResponse.Data = employers.Select(c => _mapper.Map<GetEmployerDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetEmployerDto>> GetEmployerById(int id)
        {
            var serviceResponse = new ServiceResponse<GetEmployerDto>();
            var employer = employers.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetEmployerDto>(employer); // почитать как работает automapper(преобразование типов)
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetEmployerDto>> UpdateEmployers(UpdateEmployerDto updateEmployer)
        {
            var serviceResponse = new ServiceResponse<GetEmployerDto>();
            try
            {

                var employer = employers.FirstOrDefault(c => c.Id == updateEmployer.Id);  // вопросики
                if (employer is null)
                {
                    throw new Exception($"Employer with Id '{updateEmployer.Id}' not found");
                }
                employer.NameOfCompany = updateEmployer.NameOfCompany;
                employer.AmountOfVacancies = updateEmployer.AmountOfVacancies;
                serviceResponse.Data = _mapper.Map<GetEmployerDto>(employer);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;


        }

        public async Task<ServiceResponse<List<GetEmployerDto>>> DeleteEmployer(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetEmployerDto>>();
            try
            {

                var employer = employers.First(c => c.Id == id);  // вопросики
                if (employer is null)
                {
                    throw new Exception($"Employer with Id '{id}' not found");
                }
                employers.Remove(employer);
                serviceResponse.Data = employers.Select(c => _mapper.Map<GetEmployerDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;


        }
    }
}

