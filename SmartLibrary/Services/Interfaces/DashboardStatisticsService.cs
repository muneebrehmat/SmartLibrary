using SmartLibrary.DTOs.Dashboard;
using SmartLibrary.Repositories.Interfaces;

namespace SmartLibrary.Services.Interfaces
{
    public class DashboardStatisticsService : IDashboardStatisticsService
    {
        private readonly IDashboardStatisticsRepository _statisticsRepository;

        public DashboardStatisticsService(IDashboardStatisticsRepository statisticsRepository) 
        {
            _statisticsRepository = statisticsRepository;
        }
        public async Task<StatisticsDto> GetStatisticsAsync()
        {
            return await _statisticsRepository.GetStatisticsAsync();

        }
    }
}
