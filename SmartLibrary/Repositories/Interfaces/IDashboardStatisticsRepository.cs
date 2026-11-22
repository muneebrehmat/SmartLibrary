using SmartLibrary.DTOs.Dashboard;

namespace SmartLibrary.Repositories.Interfaces
{
    public interface IDashboardStatisticsRepository
    {
        Task<StatisticsDto> GetStatisticsAsync();
    }
}
