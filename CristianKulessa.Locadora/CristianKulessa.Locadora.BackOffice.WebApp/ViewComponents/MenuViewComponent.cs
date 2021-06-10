using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
