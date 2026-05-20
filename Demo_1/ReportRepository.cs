using Microsoft.EntityFrameworkCore;
public class ReportRepository
{
    private SqLiteDbContext dbContext;
    private DbSet<Report> reports;
    public ReportRepository()
    {
        dbContext = new SqLiteDbContext();
        reports = dbContext.Reports;
    }
    public void Create(ReportCreateDto dto)
    {
        reports.Add(new Report(dto));
        dbContext.SaveChanges();
    }
    public Report[] Read()
    {
        return reports.ToArray();
    }
    public void Update(Guid id, ReportUpdateDto Dto)
    {

        Report reportsId = reports.Find(id);
        reportsId.DateReport = Dto.DateReport ?? reportsId.DateReport;
        reportsId.StartSumm = Dto.StartSumm ?? reportsId.StartSumm;
        reportsId.OnlineRevenue = Dto.OnlineRevenue ?? reportsId.OnlineRevenue;
        reportsId.CashRevenue = Dto.CashRevenue ?? reportsId.CashRevenue;
        dbContext.SaveChanges();
    }
    public void Delete(Guid id)
    {
        Report reportsId = reports.Find(id);
        reports.Remove(reportsId);
        dbContext.SaveChanges();
    }
}

public class UserRepository
{
    private SqLiteDbContext dbContext;
    private DbSet<User> users;

    public UserRepository()
    {
        dbContext = new SqLiteDbContext();
        users = dbContext.Users;
    }
    public void Create(User dto)
    {
        users.Add(dto);
        dbContext.SaveChanges();
    }
    public User[] Read()
    {
        return users.ToArray();
    }

    //public void Update(Guid id, ReportUpdateDto Dto)
    //{

    //    User reportsId = users.Find(id);
    //    reportsId.DateReport = Dto.DateReport ?? reportsId.DateReport;
    //    reportsId.StartSumm = Dto.StartSumm ?? reportsId.StartSumm;
    //    reportsId.OnlineRevenue = Dto.OnlineRevenue ?? reportsId.OnlineRevenue;
    //    reportsId.CashRevenue = Dto.CashRevenue ?? reportsId.CashRevenue;
    //    dbContext.SaveChanges();
    //}
    //public void Delete(Guid id)
    //{
    //    Report reportsId = users.Find(id);
    //    users.Remove(reportsId);
    //    dbContext.SaveChanges();
    //}
}