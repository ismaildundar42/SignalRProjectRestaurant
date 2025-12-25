using BussinesLayer.Abstract;
using DtoLayer.NotificationDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: api/notification
        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _notificationService.TGetListAll();

            var result = values.Select(x => new ResultNotificationDto
            {
                NotificationId = x.NotificationId,
                Type = x.Type,
                Icon = x.Icon,
                Description = x.Description,
                Date = x.Date,
                Status = x.Status
            }).ToList();

            return Ok(result);
        }

        // GET: api/notification/NotificationCountByStatusFalse
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        // GET: api/notification/GetAllNotificationByFalse
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult NotificationListByStatusFalse()
        {
            var values = _notificationService.TGetAllNotificationByFalse();

            var result = values.Select(x => new ResultNotificationDto
            {
                NotificationId = x.NotificationId,
                Type = x.Type,
                Icon = x.Icon,
                Description = x.Description,
                Date = x.Date,
                Status = x.Status
            }).ToList();

            return Ok(result);
        }

        // GET: api/notification/5
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetbyId(id);
            if (value == null)
                return NotFound("Bildirim bulunamadı");

            var result = new ResultNotificationDto
            {
                NotificationId = value.NotificationId,
                Type = value.Type,
                Icon = value.Icon,
                Description = value.Description,
                Date = value.Date,
                Status = value.Status
            };

            return Ok(result);
        }

        // POST: api/notification
        // Status her zaman FALSE
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto dto)
        {
            var notification = new Notification
            {
                Type = dto.Type,
                Icon = dto.Icon,
                Description = dto.Description,
                Date = DateTime.Now,   // İstersen dto.Date kullanabilirsin
                Status = false         // 🔴 ZORUNLU FALSE
            };

            _notificationService.TAdd(notification);
            return Ok("Bildirim eklendi");
        }

        // PUT: api/notification
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto dto)
        {
            var notification = _notificationService.TGetbyId(dto.NotificationId);
            if (notification == null)
                return NotFound("Bildirim bulunamadı");

            notification.Type = dto.Type;
            notification.Icon = dto.Icon;
            notification.Description = dto.Description;
            notification.Date = dto.Date;
            notification.Status = dto.Status;

            _notificationService.TUpdate(notification);
            return Ok("Bildirim güncellendi");
        }

        // DELETE: api/notification/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetbyId(id);
            if (value == null)
                return NotFound("Bildirim bulunamadı");

            _notificationService.TDelete(value);
            return Ok("Bildirim silindi");
        }
        [HttpGet("NotificationStatusChangesFalse/{id}")]
        public IActionResult NotificationStatusChangesFalse(int id)
        {
            _notificationService.TNotificationStatusChangesFalse(id);
            return Ok();
        }

        [HttpGet("NotificationStatusChangesTrue/{id}")]
        public IActionResult NotificationStatusChangesTrue(int id)
        {
            _notificationService.TNotificationStatusChangesTrue(id);
            return Ok();
        }
    }
}
