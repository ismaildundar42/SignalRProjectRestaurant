using AutoMapper;
using BussinesLayer.Abstract;
using DtoLayer.SocialMediaDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var social = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(social);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var deger = _socialMediaService.TGetbyId(id);
            _socialMediaService.TDelete(deger);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var social = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(social);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var deger = _socialMediaService.TGetbyId(id);
            return Ok(deger);
        }
    }
}
