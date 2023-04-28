using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using MvcCoreAppInsightsDonativos.Models;
using System.Diagnostics;

namespace MvcCoreAppInsightsDonativos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TelemetryClient temeletry;

        public HomeController(ILogger<HomeController> logger, TelemetryClient telemetry)
        {
            this.temeletry = telemetry;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string nombre, int donacion)
        {
            @ViewData["RES"] = nombre + "ha donado" + donacion + "€";
            temeletry.TrackEvent("DonativosRequest");
            MetricTelemetry tel = new MetricTelemetry();
            tel.Name = nombre;
            tel.Sum = donacion;
            temeletry.TrackMetric(tel);
            string msg = "";
            SeverityLevel level;
            if(donacion == 0)
            {
                level = SeverityLevel.Error;
            }else if(donacion <= 5)
            {
                level = SeverityLevel.Critical;
            }
            else if(donacion <= 20)
            {
                level = SeverityLevel.Warning;
            }
            else
            {
                level = SeverityLevel.Information;
            }
            msg = nombre + " " + donacion + "€";
            TraceTelemetry traza = new TraceTelemetry(msg, level);
            this.temeletry.TrackTrace(traza);


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}