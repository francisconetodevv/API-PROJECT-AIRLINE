using CIAAerea.Middlewares;
using CIAAerea.Services;
using CIAAerea.Validators;
using CIAAerea.Validators.Piloto;
using CIAArea.Contexts;
using CIAArea.Entities;
using CIAArea.Services;

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
builder.Services.AddTransient<AtualizarPilotoValidator>();

// Validators

/// Aeronave - Validators
builder.Services.AddTransient<AdicionarAeronaveValidator>();
builder.Services.AddTransient<AtualizarAeronaveValidator>();

/// Piloto - Validators
builder.Services.AddTransient<ExcluirAeronaveValidator>();
builder.Services.AddTransient<AdicionarPilotoValidator>();
 

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

