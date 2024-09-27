using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityPortal.Api.Interfaces;
using UniversityPortal.Api.Models;
using UniversityPortalApi.Dto;

namespace UniversityPortal.Api.Controllers
{
    [ServiceFilter(typeof(LogActionFilter))]
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;
        public NewsController(INewsService newsService, IMapper mapper)
        {
            _newsService = newsService;
            _mapper = mapper;
        }

        [HttpGet]
        [ServiceFilter(typeof(LogActionFilter))]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetAllNews()
        {
            var news = await _newsService.GetAllNewsAsync();
            var newsDtos = _mapper.Map<IEnumerable<NewsDto>>(news);
            return Ok(newsDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNewsById(int id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        [HttpPost]
        public async Task<ActionResult> PublishNews(CreateNewsDto newsDto)
        {
            var news = _mapper.Map<News>(newsDto);
            await _newsService.AddNewsAsync(news);
            return CreatedAtAction(nameof(GetAllNews), new { id = news.Id }, newsDto);
        }
    }
}
