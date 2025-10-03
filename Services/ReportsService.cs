using Microsoft.EntityFrameworkCore;
using CliqfyReportsService.Data;
using CliqfyReportsService.DTOs;

namespace CliqfyReportsService.Services
{
    public class ReportsService
    {
        private readonly ApplicationDbContext _context;

        public ReportsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DailyReportDto> GetDailyReportAsync()
        {
            var totalOrders = await _context.Ordens.CountAsync();
            var openOrders = await _context.Ordens.CountAsync(o => o.Status == "aberta");
            var inProgressOrders = await _context.Ordens.CountAsync(o => o.Status == "em_andamento");
            var completedOrders = await _context.Ordens.CountAsync(o => o.Status == "concluida");
            var cancelledOrders = await _context.Ordens.CountAsync(o => o.Status == "cancelada");
            var today = DateTime.Today;

            var completionRate = totalOrders > 0 ? (double)completedOrders / totalOrders * 100 : 0;

            return new DailyReportDto
            {
                Date = today.ToString("yyyy-MM-dd"),
                TotalOrders = totalOrders,
                OpenOrders = openOrders,
                InProgressOrders = inProgressOrders,
                CompletedOrders = completedOrders,
                CancelledOrders = cancelledOrders,
                CompletionRate = Math.Round(completionRate, 2)
            };
        }
    }
}
