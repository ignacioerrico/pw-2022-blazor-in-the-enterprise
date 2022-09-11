using Mapster;
using Microsoft.EntityFrameworkCore;
using ProgrammersWeek.TalkManager.DataAccess;
using ProgrammersWeek.TalkManager.Shared.Dto.Requests;
using ProgrammersWeek.TalkManager.Shared.Models;

namespace ProgrammersWeek.TalkManager.WebApi.Services
{
    public interface IAttendanceService
    {
        Task<List<int>?> GetTalkIdsForAsync(string participantId);
        Task<int> RegisterParticipantAsync(AttendanceRequest attendance);
    }

    public class AttendanceService : IAttendanceService
    {
        private readonly DataContext _dbContext;

        public AttendanceService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<int>?> GetTalkIdsForAsync(string participantId)
        {
            var talkIds = await _dbContext.Attendances
                .Where(a => a.ParticipantId == participantId)
                .Select(a => a.TalkId)
                .ToListAsync();

            return talkIds;
        }

        public async Task<int> RegisterParticipantAsync(AttendanceRequest attendanceRequest)
        {
            var attendance = attendanceRequest.Adapt<Attendance>();
            _dbContext.Attendances.Add(attendance);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
