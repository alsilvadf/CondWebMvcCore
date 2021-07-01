using CondWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondWebMvc.Services
{
    public class UnidadeService
    {
        private readonly CondWebMvcContext _context;

        public UnidadeService(CondWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Unidade>> ConsultarTodasUnidadesAsync()
        {
            return await _context.Unidade.ToListAsync();
        }
        public async Task<Unidade> ConsultarUnidadeIdsAsync(int id)
        {
            return await _context.Unidade.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddUnidadeAsync(Unidade obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        } 

        public async Task<Unidade> DetalharUnidadeAsync(int id)
        {
            return await _context.Unidade.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task ExcluirUnidadeAsync(int id)
        {
            var obj = await _context.Unidade.FindAsync(id);
            _context.Unidade.Remove(obj);
           await _context.SaveChangesAsync();            
        }

        public async Task EditarUnidade(Unidade obj)
        {
            bool existe = await _context.Unidade.AnyAsync(x => x.Id == obj.Id);
            if (existe)
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }

           
        }
    }
}
