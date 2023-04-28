using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF.Services;
using ServiceCountries;

namespace MvcCoreClienteWCF.Controllers
{
    public class CountriesController : Controller
    {
        private ServicesCountries service;

        public CountriesController(ServicesCountries service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            tCountryCodeAndName[] countries =
                await this.service.GetCountriesAsync();
            return View(countries);
        }

        public async Task<IActionResult> Details(string isocode)
        {
            tCountryInfo country =
                await this.service.GetCountryInfoAsync(isocode);
            return View(country);
        }
    }
}
