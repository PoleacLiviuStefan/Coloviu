using Microsoft.EntityFrameworkCore;
using Coloviu.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coloviu.Data;

namespace Coloviu.Repositories
{
    public class MaterieRepository
    {
        private readonly ColocviuDbContext _context;

        public MaterieRepository(ColocviuDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Materie>> GetAllMateriiAsync()
        {
            return await _context.Materii.ToListAsync();
        }

        public async Task<Materie> GetMaterieByIdAsync(int id)
        {
            return await _context.Materii.FindAsync(id);
        }

        public async Task AddMaterieAsync(Materie materie)
        {
            _context.Materii.Add(materie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMaterieAsync(Materie materie)
        {
            _context.Entry(materie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMaterieAsync(int id)
        {
            var materie = await _context.Materii.FindAsync(id);
            if (materie != null)
            {
                _context.Materii.Remove(materie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
