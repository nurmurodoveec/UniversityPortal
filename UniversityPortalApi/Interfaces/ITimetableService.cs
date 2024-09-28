using UniversityPortal.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityPortal.Api.Interfaces
{
    public interface ITimetableService
    {
        Task<IEnumerable<Timetable>> GetAllTimetablesAsync();
        Task<Timetable> GetTimetableByIdAsync(int id);
        Task AddTimetableAsync(Timetable timetable);
        Task UpdateTimetableAsync(Timetable timetable);
        Task DeleteTimetableAsync(int id);
    }
}
