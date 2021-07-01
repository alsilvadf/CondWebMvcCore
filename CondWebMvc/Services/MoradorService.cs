using CondWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondWebMvc.Services
{
    public class MoradorService
    {
        private readonly CondWebMvcContext _context;

        public MoradorService(CondWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Morador>> FindAllAsync()
        {
            return await _context.Morador.ToListAsync();
        }

        public async Task InsertAsync(Morador obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Morador> FindIdAsync(int id)
        {
            return await _context.Morador.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateMorador(Morador mr)
        {
             _context.Update(mr);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var obj = await _context.Morador.FindAsync(id);

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
      
    }
}
