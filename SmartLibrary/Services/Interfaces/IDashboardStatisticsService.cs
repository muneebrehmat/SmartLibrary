using SmartLibrary.DTOs.Dashboard;

namespace SmartLibrary.Services.Interfaces
{
    public interface IDashboardStatisticsService
    {
        Task<StatisticsDto> GetStatisticsAsync();

    }
}
