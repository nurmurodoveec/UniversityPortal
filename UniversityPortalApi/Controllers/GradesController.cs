using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityPortal.Api.Interfaces;
using UniversityPortal.Api.Models;
using UniversityPortal.Api.Services;
using UniversityPortalApi.Dto;

namespace UniversityPortal.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;
        public GradesController(IGradeService gradeService, IMapper mapper)
        {
            _gradeService = gradeService;
            _mapper = mapper;
        }

        [HttpGet("{studentId}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetGrades(int studentId)
        {
            var grades = await _gradeService.GetGradesByStudentIdAsync(studentId);
            var gradeDtos = _mapper.Map<IEnumerable<GradeDto>>(grades);
            return Ok(gradeDtos);
        }

        [HttpPost]
        public async Task<ActionResult> AddGrade(CreateGradeDto gradeDto)
        {
            var grade = _mapper.Map<Grade>(gradeDto);
            await _gradeService.AddGradeAsync(grade);
            return CreatedAtAction(nameof(GetGrades), new { studentId = grade.StudentId }, gradeDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGrade(int id, GradeDto gradeDto)
        {
            if (id != gradeDto.Id)
            {
                return BadRequest();
            }
            var grade = _mapper.Map<Grade>(gradeDto);

            await _gradeService.UpdateGradeAsync(grade);
            return NoContent();
        }
    }
}

