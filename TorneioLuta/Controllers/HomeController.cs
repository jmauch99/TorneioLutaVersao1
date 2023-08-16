

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TorneioLuta.Models;
using TorneioLuta.Services;

namespace TorneioLuta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILutadorService _lutadorService;

        public HomeController(ILutadorService lutadorService)
        {
            _lutadorService = lutadorService;
        }

        public IActionResult Index()
        {
            List<Lutador> lutadores = _lutadorService.GetLutadores();
            return View(lutadores);
        }

        [HttpPost]
        public IActionResult IniciarTorneio(int[] ids)
        {
            _lutadorService.InserirNoTorneio(ids);
            _lutadorService.RealizarTorneio();
            Lutador vencedor = _lutadorService.ObterVencedor();
            return View("Vencedor", vencedor);
        }
    }
}
