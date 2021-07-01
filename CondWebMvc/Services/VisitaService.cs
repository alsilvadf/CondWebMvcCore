using CondWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondWebMvc.Services
{
    public class VisitaService
    {
        private readonly CondWebMvcContext _context;

        public VisitaService(CondWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<ControleVisitas>> FindAllVisitasAsync()
        {
            return await _context.ControleVisitas.ToListAsync();
        }

        public async Task InsertAsync(ControleVisitas obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<ControleVisitas> FindIdAsync(int id)
        {
            return await _context.Visita.FirstOrDefaultAsync(x => x.Id == id);
        }        

    }
}
