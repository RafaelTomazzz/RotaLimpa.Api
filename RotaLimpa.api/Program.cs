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
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoSomee"));
});
builder.Services.AddScoped<ICEPsRepository, CEPsRepository>();
builder.Services.AddScoped<ICEPsService, CEPsService>();

builder.Services.AddScoped<IColaboradoresRepository, ColaboradoresRepository>();
builder.Services.AddScoped<IColaboradoresService, ColaboradoresService>();

builder.Services.AddScoped<IEmpresasRepository, EmpresasRepository>();
builder.Services.AddScoped<IEmpresasService, EmpresasService>();

builder.Services.AddScoped<IFrotasRepository, FrotasRepository>();
builder.Services.AddScoped<IFrotasService, FrotasService>();

builder.Services.AddScoped<IHisLoginCsRepository, HisLoginCsRepository>();
builder.Services.AddScoped<IHisLoginCsService, HisLoginCsService>();

builder.Services.AddScoped<IHisLoginMsRepository, HisLoginMsRepository>();
builder.Services.AddScoped<IHisLoginMsService, HisLoginMsService>();

builder.Services.AddScoped<IKilometragensRepository, KilometragensRepository>();
builder.Services.AddScoped<IKilometragensService, KilometragensService>();

builder.Services.AddScoped<IMotoristasRepository, MotoristasRepository>();
builder.Services.AddScoped<IMotoristasService, MotoristasService>();

builder.Services.AddScoped<IOcorrenciasRepository, OcorrenciasRepository>();
builder.Services.AddScoped<IOcorrenciasService, OcorrenciasService>();

builder.Services.AddScoped<IPeriodosRepository, PeriodosRepository>();
builder.Services.AddScoped<IPeriodosService, PeriodosService>();

builder.Services.AddScoped<IRelatoriosFinaisRepository, RelatoriosFinaisRepository>();
builder.Services.AddScoped<IRelatoriosFinaisService, RelatoriosFinaisService>();

builder.Services.AddScoped<IRotasRepository, RotasRepository>();
builder.Services.AddScoped<IRotasService, RotasService>();

builder.Services.AddScoped<IRuasRepository, RuasRepository>();
builder.Services.AddScoped<IRuasService, RuasService>();

builder.Services.AddScoped<ISetoresRepository, SetoresRepository>();
builder.Services.AddScoped<ISetoresService, SetoresService>();

builder.Services.AddScoped<ISetoresVeiculosRepository, SetoresVeiculosRepository>();
builder.Services.AddScoped<ISetoresVeiculosService, SetoresVeiculosService>();

builder.Services.AddScoped<ITrajetosRepository, TrajetosRepository>();
builder.Services.AddScoped<ITrajetosService, TrajetosService>();

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
