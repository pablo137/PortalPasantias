using PAS.Data;
using PAS.Data.Repositories;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var postgreSQLConnectionConfiguration = new PostgreSQLConfiguration(builder.Configuration.GetConnectionString("PostgreSQLConnection"));
builder.Services.AddSingleton(postgreSQLConnectionConfiguration);

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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
