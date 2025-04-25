using Microsoft.EntityFrameworkCore;
using LojaPedidosApi.Infrastructure.Data;
using LojaPedidosApi.Services;

var builder = WebApplication.CreateBuilder(args);

// adiciona os serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro do DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("LojaPedidosDb"));

// Registro do repositório
builder.Services.AddScoped<PedidoRepository, PedidoRepository>();
builder.Services.AddScoped<PedidoService>();

var app = builder.Build();

// Configuração do pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();