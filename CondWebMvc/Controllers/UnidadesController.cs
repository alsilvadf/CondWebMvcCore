using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CondWebMvc.Models;
using CondWebMvc.Services;

namespace CondWebMvc.Controllers
{
    public class UnidadesController : Controller
    {
        private readonly UnidadeService _context;

        public UnidadesController(UnidadeService context)
        {
            _context = context;
        }

        // GET: Unidades
        public async Task<IActionResult> Index()
        {
            var list = await _context.ConsultarTodasUnidadesAsync();
            return View(list);
        }

        // GET: Unidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var obj = await _context.DetalharUnidadeAsync(id.Value);
            return View(obj);
        }

        // GET: Unidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumUnidade,BlocoUnidade")] Unidade unidade)
        {
            if (ModelState.IsValid)
            {
               await _context.AddUnidadeAsync(unidade);               
                return RedirectToAction(nameof(Index));
            }
            return View(unidade);
        }

       

        // GET: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _context.ExcluirUnidadeAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _context.DetalharUnidadeAsync(id.Value);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Unidade unidade)
        {
            await _context.EditarUnidade(unidade);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int? id)
        {
            var obj = await _context.ConsultarUnidadeIdsAsync(id.Value);
            return View(obj);
           

        }

        public IActionResult teste()
        {
            return View();
        }


    }
}
