using AutoMapper;
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
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var value = _messageService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMessageDto>>(value));
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.MessageSendDate = DateTime.Now;
            createMessageDto.Status = false;

            var values = _mapper.Map<Message>(createMessageDto);

            
            _messageService.TAdd(values);
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
            var value = _mapper.Map<Message>(updateMessageDto);
            
            _messageService.TUpdate(value);
            return Ok("Message başarılı bir şekilde güncellenmiştir!");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetbyId(id);
            return Ok(_mapper.Map<GetMessageDto>(value));
        }
    }
}
