namespace WebAPI.Helpers
{
    using AutoMapper;

    using Dtos;
    using Models;

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
