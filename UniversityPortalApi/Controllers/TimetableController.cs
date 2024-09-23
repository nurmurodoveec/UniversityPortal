using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityPortal.Api.Interfaces;
using UniversityPortal.Api.Models;
using UniversityPortalApi.Dto;

namespace UniversityPortal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimetablesController : ControllerBase
    {
        private readonly ITimetableService _timetableService;
        private readonly IMapper _mapper;
        public TimetablesController(ITimetableService timetableService,IMapper mapper)
        {
            _timetableService = timetableService;
            _mapper = mapper;
        }

        [HttpGet]
      
        public async Task<ActionResult<IEnumerable<TimetableDto>>> GetTimetable(int studentId)
        {
            var timetables = await _timetableService.GetAllTimetablesAsync();
            var timetableDtos = _mapper.Map<IEnumerable<TimetableDto>>(timetables);
            return Ok(timetableDtos);
        }

        [HttpPost]
        public async Task<ActionResult> AddTimetableEntry(TimetableDto timetableDto)
        {
            var timetable = _mapper.Map<Timetable>(timetableDto);
            await _timetableService.AddTimetableAsync(timetable);
            return CreatedAtAction(nameof(GetTimetable), new { id = timetable.Id }, timetableDto);
        }
    }
}
