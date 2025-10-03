var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoint para relatórios diários
app.MapGet("/reports/daily", () =>
{
   var report = new {
     date = DateTime.Now.ToString("yyyy-MM-dd"),
     totalOrders = 15,
     completedOrders = 12,
     pendingOrders = 3,
     completionRate = 80.0
   };
   
   return report;
})
.WithName("GetDailyReport")
.WithOpenApi();

app.Run();
