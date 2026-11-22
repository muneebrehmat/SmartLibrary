using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLibrary.Services.Interfaces;

namespace SmartLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardStatisticsController : ControllerBase
    {
        private readonly IDashboardStatisticsService _statisticsService;

        public DashboardStatisticsController(IDashboardStatisticsService statisticsService) 
        {
            _statisticsService = statisticsService;
        }
        [HttpGet("Statitics")]
        public async Task<IActionResult> GetStatistics()
        {
            var result = await _statisticsService.GetStatisticsAsync();
            return Ok(result);
        }
    }
}
