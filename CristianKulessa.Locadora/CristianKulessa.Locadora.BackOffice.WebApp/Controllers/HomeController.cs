using CristianKulessa.Locadora.BackOffice.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CristianKulessa.Locadora.BackOffice.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration config;

        public HomeController(
            ILogger<HomeController> logger,
            IConfiguration config)
        {
            _logger = logger;
            this.config = config;
        }
        public IActionResult Index()
        {
            var urlApiTipo = config.GetSection("ApiSettings")["UrlApiTipo"];
            ViewBag.UrlApiTipo = urlApiTipo;

            var urlApiImovelTipo = config.GetSection("ApiSettings")["UrlApiImovelTipo"];
            ViewBag.UrlApiImovelTipo = urlApiImovelTipo;

            return View();
        }
        public IActionResult Detail(int id = 0)
        {
            ViewBag.Id = id;

            var urlApiBairro = config.GetSection("ApiSettings")["UrlApiBairro"];
            ViewBag.UrlApiBairro = urlApiBairro;

            var urlApiCEP = config.GetSection("ApiSettings")["UrlApiCEP"];
            ViewBag.UrlApiCEP = urlApiCEP;

            var urlApiCidade = config.GetSection("ApiSettings")["UrlApiCidade"];
            ViewBag.UrlApiCidade = urlApiCidade;

            var urlApiTipo = config.GetSection("ApiSettings")["UrlApiTipo"];
            ViewBag.UrlApiTipo = urlApiTipo;

            var urlApiImovelTipo = config.GetSection("ApiSettings")["UrlApiImovelTipo"];
            ViewBag.UrlApiImovelTipo = urlApiImovelTipo;

            var urlApiImovel = config.GetSection("ApiSettings")["UrlApiImovel"];
            ViewBag.UrlApiImovel = urlApiImovel;

            var urlApiUF = config.GetSection("ApiSettings")["UrlApiUF"];
            ViewBag.UrlApiUF = urlApiUF;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
