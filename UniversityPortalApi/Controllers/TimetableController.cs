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
    [Authorize]
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
        public async Task<ActionResult> AddTimetableEntry(CreateTimetableDto timetableDto)
        {
            var timetable = _mapper.Map<Timetable>(timetableDto);
            await _timetableService.AddTimetableAsync(timetable);
            return CreatedAtAction(nameof(GetTimetable), new { id = timetable.Id }, timetableDto);
        }
   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimetableEntry(int id)
        {
            var timetableEntry = await _timetableService.GetTimetableByIdAsync(id);
            if (timetableEntry == null)
            {
                return NotFound(new { message = "Timetable entry not found" });
            }

            await _timetableService.DeleteTimetableAsync(id);
            return Ok(new { message = "Timetable entry deleted successfully" });
        }

    }
}
