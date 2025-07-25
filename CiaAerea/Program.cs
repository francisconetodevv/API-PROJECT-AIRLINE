using CIAAerea.Middlewares;
using CIAAerea.Services;
using CIAAerea.Validators;
using CIAAerea.Validators.Cancelamento;
using CIAAerea.Validators.Manutencao;
using CIAAerea.Validators.Piloto;
using CIAAerea.Validators.Voo;
using CIAArea.Contexts;
using CIAArea.Entities;
using CIAArea.Services;
using DinkToPdf;
using DinkToPdf.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência pelo aspnet

// Context
builder.Services.AddDbContext<CiaAereaContext>();

// Services
builder.Services.AddTransient<AeronaveServices>();
builder.Services.AddTransient<PilotoService>();
builder.Services.AddTransient<VooService>();
builder.Services.AddTransient<ManutencaoService>();


// Validators
builder.Services.AddTransient<AtualizarPilotoValidator>();
builder.Services.AddTransient<ExcluirPilotoValidator>();
builder.Services.AddTransient<AdicionarPilotoValidator>();

/// Aeronave - Validators
builder.Services.AddTransient<AdicionarAeronaveValidator>();
builder.Services.AddTransient<AtualizarAeronaveValidator>();

/// Piloto - Validators
builder.Services.AddTransient<ExcluirAeronaveValidator>();
builder.Services.AddTransient<AdicionarPilotoValidator>();

// Voo - Validators
builder.Services.AddTransient<AdicionarVooValidator>();
builder.Services.AddTransient<AtualizarVooValidator>();
builder.Services.AddTransient<ExcluirVooValidator>();
builder.Services.AddTransient<CancelarVooValidator>();

// Manutencao - Validators
builder.Services.AddTransient<AdicionarManutencaoValidator>();

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); // Adicione esta linha AQUI!
app.UseMiddleware<ValidationExceptionHandlerMiddleware>();

app.Run();

