using CIAAerea.Validators;
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
builder.Services.AddDbContext<CiaAereaContext>();
builder.Services.AddTransient<AeronaveServices>();
builder.Services.AddTransient<AdicionarAeronaveValidator>();
builder.Services.AddTransient<AtualizarAeronaveValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); // Adicione esta linha AQUI!

app.Run();

