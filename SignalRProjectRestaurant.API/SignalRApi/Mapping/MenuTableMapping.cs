using AutoMapper;
using DtoLayer.MenuTableDto;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class MenuTableMapping : Profile
    {
        public MenuTableMapping()
        {
            CreateMap<MenuTable,CreateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable,GetMenuTableDto>().ReverseMap();
            CreateMap<MenuTable,ResultMenuTableDto>().ReverseMap();
            CreateMap<MenuTable,UpdateMenuTableDto>().ReverseMap();
        }
    }
}
