namespace Web_API2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employer, GetEmployerDto>();
            CreateMap<AddEmployerDto, Employer>();
        }
    }
}
