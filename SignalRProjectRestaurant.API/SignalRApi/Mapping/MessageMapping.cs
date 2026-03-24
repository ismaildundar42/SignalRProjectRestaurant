using AutoMapper;
using DtoLayer.MessageDto;
using EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<CreateMessageDto,Message>().ReverseMap();
            CreateMap<ResultMessageDto,Message>().ReverseMap();
            CreateMap<UpdateMessageDto,Message>().ReverseMap();
            CreateMap<GetMessageDto,Message>().ReverseMap();
        }
    }
}
