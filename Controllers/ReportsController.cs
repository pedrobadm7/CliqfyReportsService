using Microsoft.AspNetCore.Mvc;
using CliqfyReportsService.Services;
using CliqfyReportsService.DTOs;

namespace CliqfyReportsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ReportsService _reportsService;

        public ReportsController(ReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet("daily")]
        public async Task<ActionResult<DailyReportDto>> GetDailyReport()
        {
            try
            {
                var report = await _reportsService.GetDailyReportAsync();
                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro interno do servidor", message = ex.Message });
            }
        }
    }
}
