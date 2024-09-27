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
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        public SubjectsController(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            var subjectDtos = _mapper.Map<IEnumerable<SubjectDto>>(subjects);
            return Ok(subjectDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubjectById(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult> AddSubject(CreateSubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);
            await _subjectService.AddSubjectAsync(subject);
            return CreatedAtAction(nameof(GetAllSubjects), new { id = subject.Id }, subject);
        }
    }
}
