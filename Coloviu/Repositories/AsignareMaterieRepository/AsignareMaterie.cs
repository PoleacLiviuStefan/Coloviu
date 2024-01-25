using Microsoft.EntityFrameworkCore;
using Coloviu.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coloviu.Data;

namespace Coloviu.Repositories
{
    public class AsignareMaterieRepository
    {
        private readonly ColocviuDbContext _context;

        public AsignareMaterieRepository(ColocviuDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AsignareMaterie>> GetAllAsignariMateriiAsync()
        {
            return await _context.AsignariMaterii.ToListAsync();
        }

        public async Task<IEnumerable<AsignareMaterie>> GetAsignariMateriiByProfesorAsync(int profesorId)
        {
            return await _context.AsignariMaterii.Where(a => a.ProfesorId == profesorId).ToListAsync();
        }

        public async Task<IEnumerable<AsignareMaterie>> GetAsignariMateriiByMaterieAsync(int materieId)
        {
            return await _context.AsignariMaterii.Where(a => a.MaterieId == materieId).ToListAsync();
        }

        public async Task AddAsignareMaterieAsync(AsignareMaterie asignare)
        {
            _context.AsignariMaterii.Add(asignare);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsignareMaterieAsync(int profesorId, int materieId)
        {
            var asignare = await _context.AsignariMaterii.FirstOrDefaultAsync(a => a.ProfesorId == profesorId && a.MaterieId == materieId);
            if (asignare != null)
            {
                _context.AsignariMaterii.Remove(asignare);
                await _context.SaveChangesAsync();
            }
        }
    }
}
