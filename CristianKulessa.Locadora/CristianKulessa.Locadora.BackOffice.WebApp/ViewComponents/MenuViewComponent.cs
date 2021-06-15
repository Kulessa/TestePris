using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CristianKulessa.Locadora.BackOffice.WebApp.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IConfiguration config;

        public MenuViewComponent(IConfiguration config)
        {
            this.config = config;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
