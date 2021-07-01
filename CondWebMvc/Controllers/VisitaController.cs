using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondWebMvc.Models;
using CondWebMvc.Models.ViewModels;
using CondWebMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace CondWebMvc.Controllers
{
    public class VisitaController : Controller
    {
        private readonly VisitaService _visitaService;
        private readonly UnidadeService _unidadeService;
        private readonly MoradorService _moradorService;

        public VisitaController(UnidadeService unidadeService, MoradorService moradorService, VisitaService visitaService)
        {
            _unidadeService = unidadeService;
            _moradorService = moradorService;
            _visitaService = visitaService;
        }
        public async Task<IActionResult> Index()
        {
            var obj = await _visitaService.FindAllVisitasAsync();
            return View(obj);
        }

        public async Task<IActionResult> Create()
        {
            var unidades = await _unidadeService.ConsultarTodasUnidadesAsync();
            var moradores = await _moradorService.FindAllAsync();
            var viewModel = new VisitaFormViewModels { Unidades = unidades, Moradores = moradores };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ControleVisitas visita)
        {
            if (!ModelState.IsValid)
            {
                var unidades = await _unidadeService.ConsultarTodasUnidadesAsync();
                var viewModel = new VisitaFormViewModels { Visita = visita, Unidades = unidades };
                return View(viewModel);
            }

            await _visitaService.InsertAsync(visita);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            var obj = await _visitaService.FindIdAsync(id.Value);

            return View(obj);
        }

    }
}