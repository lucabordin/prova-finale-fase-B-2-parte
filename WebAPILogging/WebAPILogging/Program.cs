using Microsoft.EntityFrameworkCore;
using WebAPILogging.Services;
using WebAPIProvaProgettoFinale.DataSource;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LoggingDBContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("cnPostgres")));

builder.Services.AddScoped<LoggingDBContext, LoggingDBContext>();
builder.Services.AddScoped<ILogService, LogService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500",
                                "http://localhost",
                                "http://192.168.1.214");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Policy1");

app.UseAuthorization();

app.MapControllers();

app.Run();
