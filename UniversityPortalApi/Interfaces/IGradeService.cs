using UniversityPortal.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityPortal.Api.Interfaces
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>> GetAllGradesAsync();
        Task<Grade> GetGradeByIdAsync(int id);
        Task AddGradeAsync(Grade grade);
        Task UpdateGradeAsync(Grade grade);
        Task DeleteGradeAsync(int id);
        Task<IEnumerable<Grade>> GetGradesByStudentIdAsync(int studentId);
    }
}
