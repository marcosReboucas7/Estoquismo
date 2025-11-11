using Estoquismo.Entities;
using Estoquismo.Context;
using Microsoft.EntityFrameworkCore;

namespace Estoquismo.Services
{
    public class TecnicoService : ITecnicoService
    {

        private readonly AppDbContext _context;

        public TecnicoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tecnicos>> GetAllTecnicosAsync()
        {
           return await _context.Tecnicos.ToListAsync();
        }

        public async Task<IEnumerable<Tecnicos>> GetTecnicoByIdAsync(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("O ID deve ser um número positivo.", nameof(id));
            }
            return await _context.Tecnicos.Where(t => t.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<Tecnicos>> GetTecnicoByNameAsync(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("O nome não pode ser vazio ou nulo.", nameof(name));
            }
            else
            {
                return await _context.Tecnicos.Where(t => t.Name.Contains(name)).ToListAsync();
            }

        }

        public async Task<IEnumerable<Tecnicos>> GetTecnicoByEmailAsync(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email não encontrado ou cadastrado.", nameof(email));
            }
            else
            {
                return await _context.Tecnicos.Where(t => t.Email.Contains(email)).ToListAsync();
            }
        }

        public async Task<Tecnicos> CreateTecnicoAsync(Tecnicos tecnico)
        {
            _context.Tecnicos.Add(tecnico);
            await _context.SaveChangesAsync();
            return tecnico;
        }

        public async Task<Tecnicos> UpdateTecnicoAsync(int id, Tecnicos tecnico)
        {
            var existingTecnico = await _context.Tecnicos.FindAsync(id);
            if (existingTecnico == null)
            {
                throw new KeyNotFoundException("Técnico não encontrado.");
            }
            existingTecnico.Name = tecnico.Name;
            existingTecnico.Email = tecnico.Email;
            await _context.SaveChangesAsync();
            return existingTecnico;
        }

        public async Task<bool> DeleteTecnicoAsync(int id)
        {
            var tecnico = await _context.Tecnicos.FindAsync(id);
            if (tecnico == null)
            {
                return false;
            }
            _context.Tecnicos.Remove(tecnico);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
