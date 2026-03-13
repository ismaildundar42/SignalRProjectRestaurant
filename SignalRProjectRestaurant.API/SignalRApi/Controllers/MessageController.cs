using BussinesLayer.Abstract;
using DtoLayer.MessageDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var value = _messageService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                Mail = createMessageDto.Mail,
                MessageContent = createMessageDto.MessageContent,
                MessageSendDate = DateTime.Now,
                NameSurname = createMessageDto.NameSurname,
                Phone = createMessageDto.Phone,
                Status = false,
                Subject = createMessageDto.Subject
            };
            _messageService.TAdd(message);
            return Ok("Message Başarılı Bir Şekilde Gönderildi!");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetbyId(id);
            _messageService.TDelete(value);
            return Ok("Message başarılı bir şekilde silinmiştir!");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
                Mail = updateMessageDto.Mail,
                MessageContent = updateMessageDto.MessageContent,
                MessageSendDate = updateMessageDto.MessageSendDate,
                NameSurname = updateMessageDto.NameSurname,
                Phone = updateMessageDto.Phone,
                Status = false,
                Subject = updateMessageDto.Subject,
                MessageId = updateMessageDto.MessageId
            };
            _messageService.TUpdate(message);
            return Ok("Message başarılı bir şekilde güncellenmiştir!");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            return Ok(_messageService.TGetbyId(id));
        }
    }
}
