using CondWebMvc.Models;
using CondWebMvc.Models.ViewModels;
using CondWebMvc.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondWebMvc.Controllers
{
    public class MoradorController : Controller
    {
        private readonly UnidadeService _unidadeService;
        private readonly MoradorService _moradorService;

        public MoradorController(UnidadeService unidadeService, MoradorService moradorService)
        {
            _unidadeService = unidadeService;
            _moradorService = moradorService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _moradorService.FindAllAsync();
            return View(list);

        }     

        public async Task<IActionResult> Create()
        {
            var unidades = await _unidadeService.ConsultarTodasUnidadesAsync();
            var viewModel = new MoradorFormViewModels { Unidades = unidades };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Morador morador)
        {
            if (!ModelState.IsValid)
            {
                var unidades = await _unidadeService.ConsultarTodasUnidadesAsync();
                var viewModel = new MoradorFormViewModels { Morador = morador, Unidades = unidades };
                return View(viewModel);
            }

            await _moradorService.InsertAsync(morador);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index), "Id nulo");
            }

            var obj = await _moradorService.FindIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Index), "Obj retornou null");
            }

            List<Unidade> unidades = await _unidadeService.ConsultarTodasUnidadesAsync();

            MoradorFormViewModels viewModel = new MoradorFormViewModels { Morador = obj, Unidades = unidades };
            return View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, Morador morador)
        {
            if (!ModelState.IsValid)
            {
                var unidades = await _unidadeService.ConsultarTodasUnidadesAsync();
                var viewModel = new MoradorFormViewModels { Morador = morador, Unidades = unidades };
                return View(viewModel);
            }

            if (id != morador.Id)
            {
                return RedirectToAction(nameof(Index), "Registro nao encontrado");
            }

            await _moradorService.UpdateMorador(morador);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            var obj = await _moradorService.FindIdAsync(id.Value);

            return View(obj);
        }




        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _moradorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _moradorService.FindIdAsync(id.Value);
            return View(obj);



        }




    }
}