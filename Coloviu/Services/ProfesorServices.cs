using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Coloviu.Models;
using Coloviu.Data;
using System;

namespace Coloviu.Services
{
    public class ProfesorService
    {
        private readonly ColocviuDbContext _context;

        public ProfesorService(ColocviuDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesor>> GetAllProfesoriAsync()
        {
            return await _context.Profesori.ToListAsync();
        }

        public async Task<Profesor> GetProfesorByIdAsync(int id)
        {
            return await _context.Profesori.FindAsync(id);
        }

        public async Task AddProfesorAsync(Profesor profesor)
        {
            _context.Profesori.Add(profesor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfesorAsync(Profesor profesor)
        {
            _context.Entry(profesor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfesorAsync(int id)
        {
            var profesor = await _context.Profesori.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesori.Remove(profesor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
