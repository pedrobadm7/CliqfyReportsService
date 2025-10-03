using Microsoft.EntityFrameworkCore;
using CliqfyReportsService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoint para relatórios diários
app.MapGet("/reports/daily", async (ApplicationDbContext db) =>
{
    var totalOrders = await db.Ordens.CountAsync();
    var openOrders = await db.Ordens.CountAsync(o => o.Status == "aberta");
    var inProgressOrders = await db.Ordens.CountAsync(o => o.Status == "em_andamento");
    var completedOrders = await db.Ordens.CountAsync(o => o.Status == "concluida");
    var cancelledOrders = await db.Ordens.CountAsync(o => o.Status == "cancelada");
    var today = DateTime.Today;

    var completionRate = totalOrders > 0 ? (double)completedOrders / totalOrders * 100 : 0;

    var report = new {
        date = today.ToString("yyyy-MM-dd"),
        totalOrders,
        openOrders,
        inProgressOrders,
        completedOrders, 
        cancelledOrders,
        completionRate = Math.Round(completionRate, 2)
    };
    
    return report;
})
.WithName("GetDailyReport")
.WithOpenApi();

app.Run();
