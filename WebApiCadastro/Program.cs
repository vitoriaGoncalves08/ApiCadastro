using Microsoft.EntityFrameworkCore;
using WebApiCadastro.DataContext;
using WebApiCadastro.Services.UsuarioService;

var builder = WebApplication.CreateBuilder(args);

// Add depend�ncias.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Para quando fazer uma gest�o de depen�ncias do IUsuarioInterface utilizar os m�todos da UsuarioService
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();

// Para utilizarmos as nossas configura��es do appsettings
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
