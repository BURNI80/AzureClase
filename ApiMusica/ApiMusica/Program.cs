using ApiMusica.Data;
using ApiMusica.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryMusica>();
builder.Services.AddDbContext<MusicaContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Api CRUD Musica de ejemplo para el examen",
        Description = "Prueba de examen",
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options => {
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api CRUD Musica v1");
    options.RoutePrefix = "";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
