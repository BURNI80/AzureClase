using ApiOAuthEmpleados.Data;
using ApiOAuthEmpleados.Helpers;
using ApiOAuthEmpleados.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiOAuthEmpleados
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            HelperOAuthToken helper = new HelperOAuthToken(builder.Configuration);
            builder.Services.AddSingleton<HelperOAuthToken>();
            builder.Services.AddAuthentication(helper.GetAuthenticationOptions()).AddJwtBearer(helper.GetJwtOptions());

            // Add services to the container.

            string connectionString = builder.Configuration.GetConnectionString("SqlServer");

            builder.Services.AddTransient<RepositoryEmpleados>();
            builder.Services.AddDbContext<EmpleadosContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API OAuth Empleados 2023",
                    Version = "v1",
                    Description = "Ejemplo Seguridad API Tokens"
                });
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API OAuth Empleados");
                options.RoutePrefix = "";
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
