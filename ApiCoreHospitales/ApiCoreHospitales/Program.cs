using ApiCoreHospitales.Data;
using ApiCoreHospitales.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string sqlcon = builder.Configuration.GetConnectionString("Azure");
builder.Services.AddTransient<RepositoryHospitales>();
builder.Services.AddDbContext<ContextHospitales>(options => options.UseSqlServer(sqlcon));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
//DEBEMOS INDICAR QUE LA PAGINA DE INICIO DE 
//NUESTRA APLICACION SERA SWAGGER
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        url: "/swagger/v1/swagger.json", name: "Api v1");
    options.RoutePrefix = "";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
