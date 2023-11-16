using Microsoft.EntityFrameworkCore;

using RotaLimpa.Api.Data;
using RotaLimpa.Api.Repositories.Interfaces;
using RotaLimpa.Api.Repositories;
using RotaLimpa.Api.Services;
using RotaLimpa.Api.Repositories.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal"));
});
builder.Services.AddScoped<ICEPsRepository, CEPsRepository>();
builder.Services.AddScoped<ICEPsService, CEPsService>();

builder.Services.AddScoped<IFrotasRepository, FrotasRepository>();
builder.Services.AddScoped<IFrotasService, FrotasService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
