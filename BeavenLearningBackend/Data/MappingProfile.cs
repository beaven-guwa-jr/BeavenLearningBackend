using AutoMapper;
using BeavenLearningBackend.Models;

namespace BeavenLearningBackend.Data;

public class MappingProfile : Profile
{
    public MappingProfile() 
    { 
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
