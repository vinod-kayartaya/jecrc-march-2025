using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductServiceWithEFAndSecurity.Data;
using ProductServiceWithEFAndSecurity.Services;
using ProductServiceWithEFAndSecurity.Models;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging()
               .EnableDetailedErrors();
    }
});

// JWT Configuration
var jwtKey = builder.Configuration["JwtSettings:Key"] ?? 
    "your-super-secret-key-with-at-least-32-characters"; // Fallback key for development
var key = Encoding.ASCII.GetBytes(jwtKey);

// Register AuthService with DbContext
builder.Services.AddScoped<IAuthService>(provider => 
    new AuthService(provider.GetRequiredService<ProductDbContext>(), jwtKey));

// JWT Authentication
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false; // Set to true in production
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Create and seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ProductDbContext>();
        
        // First ensure database is deleted to start fresh
        context.Database.EnsureDeleted();
        
        // Then create the database and tables
        context.Database.EnsureCreated();

        // Now seed the admin user
        var adminUser = new User
        {
            Username = "admin",
            Password = BCrypt.Net.BCrypt.HashPassword("admin123")
        };
        context.Users.Add(adminUser);
        context.SaveChanges();
        
        Console.WriteLine("Database created and seeded successfully!");
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while initializing the database.");
        throw; // Re-throw the exception to fail fast if database initialization fails
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add authentication middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
