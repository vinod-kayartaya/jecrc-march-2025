using Microsoft.EntityFrameworkCore;
using QnA_WebAPI_Project.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=.\\SQLEXPRESS;Database=jecrc_recap_session;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
    // Enable detailed EF Core logging
    options.EnableSensitiveDataLogging()
           .EnableDetailedErrors()
           .LogTo(Console.WriteLine);
});

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
