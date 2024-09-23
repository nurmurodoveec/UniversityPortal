using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityPortal.Api.Data;
using UniversityPortal.Api.Interfaces;
using UniversityPortal.Api.Models;

namespace UniversityPortal.Api.Services
{
    public class TimetableService : ITimetableService
    {
        private readonly ApplicationDbContext _context;

        public TimetableService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Timetable>> GetAllTimetablesAsync()
        {
            return await _context.Timetables.ToListAsync();
        }

        public async Task<Timetable> GetTimetableByIdAsync(int id)
        {
            return await _context.Timetables.FindAsync(id);
        }

        public async Task AddTimetableAsync(Timetable timetable)
        {
            _context.Timetables.Add(timetable);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTimetableAsync(Timetable timetable)
        {
            _context.Timetables.Update(timetable);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTimetableAsync(int id)
        {
            var timetable = await _context.Timetables.FindAsync(id);
            if (timetable != null)
            {
                _context.Timetables.Remove(timetable);
                await _context.SaveChangesAsync();
            }
        }
    }
}
