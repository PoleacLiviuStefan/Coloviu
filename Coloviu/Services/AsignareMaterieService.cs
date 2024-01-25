using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Coloviu.Models;
using System;
using Coloviu.Data;

namespace Coloviu.Services
{
    public class AsignareMaterieService
    {
        private readonly ColocviuDbContext _context;

        public AsignareMaterieService(ColocviuDbContext context)
        {
            _context = context;
        }

        public async Task AsignareMaterieLaProfesorAsync(int profesorId, int materieId)
        {
            var asignare = new AsignareMaterie
            {
                ProfesorId = profesorId,
                MaterieId = materieId
            };

            _context.AsignariMaterii.Add(asignare);
            await _context.SaveChangesAsync();
        }
    }
}
