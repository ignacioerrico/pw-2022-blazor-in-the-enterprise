using Mapster;
using Microsoft.EntityFrameworkCore;
using ProgrammersWeek.TalkManager.DataAccess;
using ProgrammersWeek.TalkManager.Shared.Dto.Responses;
using ProgrammersWeek.TalkManager.Shared.Models;

namespace ProgrammersWeek.TalkManager.WebApi.Services
{
    public interface ITalkService
    {
        Task<List<TalkResponse>> GetAllAsync();
        Task<TalkResponse?> GetByIdAsync(int talkId);
        Task<List<TalkResponse>> GetByAuthorIdAsync(int authorId);
        Task<List<TalkResponse>> GetByInterestAreaIdAsync(int interestAreaId);
        Task<List<TalkResponse>> GetByRegionIdAsync(int regionId);
    }

    public class TalkService : ITalkService
    {
        private readonly DataContext _dbContext;

        public TalkService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TalkResponse>> GetAllAsync()
        {
            var talks = await Talks().ToListAsync();
            return talks.Adapt<List<TalkResponse>>();
        }

        public async Task<TalkResponse?> GetByIdAsync(int talkId)
        {
            var talk = await Talks().SingleOrDefaultAsync(t => t.Id == talkId);
            return talk?.Adapt<TalkResponse>();
        }

        public async Task<List<TalkResponse>> GetByAuthorIdAsync(int authorId)
        {
            var talks = await Talks()
                .Where(t => t.Authors != null && t.Authors.Any(a => a.Id == authorId))
                .ToListAsync();
            return talks.Adapt<List<TalkResponse>>();
        }

        public async Task<List<TalkResponse>> GetByInterestAreaIdAsync(int interestAreaId)
        {
            var talks = await Talks()
                .Where(t => t.InterestAreaId == interestAreaId)
                .ToListAsync();
            return talks.Adapt<List<TalkResponse>>();
        }

        public async Task<List<TalkResponse>> GetByRegionIdAsync(int regionId)
        {
            var talks = await Talks()
                .Where(t => t.RegionId == regionId)
                .ToListAsync();
            return talks.Adapt<List<TalkResponse>>();
        }

        private IQueryable<Talk> Talks() =>
            _dbContext.Talks
                .OrderBy(t => t.DateTimeUtc)
                .Include(t => t.Authors)
                .Include(t => t.InterestArea)
                .Include(t => t.Region)
                .AsQueryable();
    }
}
