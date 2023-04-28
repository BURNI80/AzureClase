using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebJobChollometro.Data;
using WebJobChollometro.Repositories;

string connectionString = @"Data Source=agcclase.database.windows.net;Initial Catalog=BIBLIOTECAS;User ID=adminsql; Password=Admin123";

var provider = new ServiceCollection()
    .AddTransient<RepositoryChollo>()
    .AddDbContext<ChollometroContext>(options => options.UseSqlServer(connectionString)).BuildServiceProvider();

RepositoryChollo repo = provider.GetService<RepositoryChollo>();

await repo.PopularChollosAsync();
