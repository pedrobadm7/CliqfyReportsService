namespace CliqfyReportsService.DTOs
{
    public class DailyReportDto
    {
        public string Date { get; set; } = string.Empty;
        public int TotalOrders { get; set; }
        public int OpenOrders { get; set; }
        public int InProgressOrders { get; set; }
        public int CompletedOrders { get; set; }
        public int CancelledOrders { get; set; }
        public double CompletionRate { get; set; }
    }
}
