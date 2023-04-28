using MvcCoreClienteWCF.Controllers;
using MvcCoreClienteWCF.Services;
using ReferenceCatastro;
using ReferenceClientes;
using ReferenceMetodosVarios;
using ServiceReference1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<CallejerodelasedeelectrónicadelcatastroSoapClient>();
builder.Services.AddTransient<ServiceCatastro>();
builder.Services.AddTransient<ServicesCountries>();
builder.Services.AddTransient<ServiceMetodosVarios>();
builder.Services.AddTransient<MetodosVariosContractClient>();
builder.Services.AddTransient<ServiceCoches>();
builder.Services.AddTransient<CochesContractClient>();
builder.Services.AddTransient<ServiceClientes>();
builder.Services.AddTransient<ClientesContractClient>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
