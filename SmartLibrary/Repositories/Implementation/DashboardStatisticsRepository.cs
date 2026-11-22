using Microsoft.EntityFrameworkCore;
using SmartLibrary.Data;
using SmartLibrary.DTOs.Dashboard;
using SmartLibrary.Repositories.Interfaces;

namespace SmartLibrary.Repositories.Implementation
{
    public class DashboardStatisticsRepository : IDashboardStatisticsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DashboardStatisticsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StatisticsDto> GetStatisticsAsync()
        {
            var totalBooks = await _dbContext.Books.CountAsync();
            var totalMembers = await _dbContext.Users.CountAsync();
            var totalBorrowed = await _dbContext.Borrowings.Where(b=>b.ReturnDate==null).CountAsync();

            return new StatisticsDto
            {
                TotalBooks = totalBooks,
                TotalIssuedBook = totalBorrowed,
                TotalMembers = totalMembers
            };
        }
    }
}