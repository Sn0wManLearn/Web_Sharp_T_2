using AutoMapper;
using Web_Sharp_T_2.DTO;

namespace Web_Sharp_T_2.Repositories
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Product, ProductDTO>(MemberList.Destination).ReverseMap();
            CreateMap<Category, CategoryDTO>(MemberList.Destination).ReverseMap();
        }
    }
}
