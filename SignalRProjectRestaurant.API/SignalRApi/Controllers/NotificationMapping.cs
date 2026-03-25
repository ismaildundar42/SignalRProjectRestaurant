using AutoMapper;
using DtoLayer.NotificationDto;
using EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
        }
    }
}
