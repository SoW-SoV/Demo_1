using Microsoft.EntityFrameworkCore.Storage;
using static SqLiteDbContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

//List<Report> reports = [];
//for(int i = 0; i < 10; i++)
//{
//    reports.Add(new Report(new ReportCreateDto (new DateOnly(2026, 1, 1), 100+i, 101+i, 102+i)));
//}
ReportRepository users = new ReportRepository();

var ReportPath = "/reports";
app.MapGet(ReportPath, users.Read);
app.MapPost(ReportPath, users.Create);
app.MapDelete(ReportPath + "/{id}", users.Delete);
app.MapPut(ReportPath + "/{id}", users.Update);

UserRepository userRepository = new UserRepository();
userRepository.Create(new User() { Login = "demo", Password = "demo" });
var UserPath = "/users";
app.MapGet(UserPath, userRepository.Read);
app.MapPost(UserPath, userRepository.Create);
app.Run();
