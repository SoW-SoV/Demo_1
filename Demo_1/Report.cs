public class Report
{
    public Report() {}
    public Report(ReportCreateDto dto)
    {
        DateReport = dto.DateReport;
        StartSumm = dto.StartSumm;
        OnlineRevenue = dto.OnlineRevenue;
        CashRevenue = dto.CashRevenue;
    }
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateOnly DateReport { get; set; }
    public decimal StartSumm { get; set; }
    public decimal OnlineRevenue { get; set; }
    public decimal CashRevenue {  get; set; }
    public decimal TotalSumm => StartSumm + OnlineRevenue + CashRevenue;
}