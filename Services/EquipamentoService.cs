using Estoquismo.Context;
using Estoquismo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Estoquismo.Services
{
    public class EquipamentoService : IEquipamentoService
    {
        private readonly AppDbContext _context;

        public EquipamentoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipamentos>> GetAllEquipamentosAsync()
        {
            return await _context.Equipamentos.ToListAsync();
        }

        public async Task<Equipamentos> GetEquipamentosByIdAsync(int id)
        {
            var client = await _context.Equipamentos.FindAsync(id);

            if (client == null)
            
                throw new KeyNotFoundException($"Cliente com o ID {id} não encontrado");

            return client;
        }

        public async Task<IEnumerable<Equipamentos>> GetEquipamentosByNameAsync(string name)
        {
            return await _context.Equipamentos
            .Where(c => c.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Equipamentos>> GetEquipamentosByTypeAsync(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return Enumerable.Empty<Equipamentos>();

            if (Enum.TryParse<TipoEquipamento>(type, true, out var tipoEnum))
            {
                return await _context.Equipamentos
                    .Where(e => e.TipoEquipamento == tipoEnum)
                    .ToListAsync();
            }

            // se não conseguir converter, retorna vazio (ou ajuste para outra lógica)
            return Enumerable.Empty<Equipamentos>();
        }

        public async Task<IEnumerable<Equipamentos>> GetEquipamentosByMonthAsync(int month, int year)
        {
            return await _context.Equipamentos
            .Where(c => c.DataCadastro.Month == month && c.DataCadastro.Year == year)
            .ToListAsync();
        }

        public async Task<IEnumerable<Equipamentos>> GetEquipamentosByNameAndMonthAsync(string name, int month, int year)
        {
            return await _context.Equipamentos
            .Where(c => 
                c.Name == name && 
                c.DataCadastro.Month == month && 
                c.DataCadastro.Year == year)
            .ToListAsync();
        }

        public async Task<IEnumerable<Equipamentos>> GetEquipamentosByNameMonthAndTypeAsync(string name, int month, int year, TipoEquipamento tipo)
        {
            return await _context.Equipamentos
            .Where(c => 
                c.Name == name && 
                c.DataCadastro.Month == month && 
                c.DataCadastro.Year == year && 
                c.TipoEquipamento == tipo)
            .ToListAsync();
        }
        public async Task<Equipamentos> CreateEquipamentosAsync(Equipamentos equipamento)
        {
            _context.Equipamentos.Add(equipamento);
            await _context.SaveChangesAsync();
            return equipamento;
        }
        public async Task<Equipamentos> UpdateEquipamentosAsync(int id, Equipamentos equipamento)
        {
            var existingEquipamento = await _context.Equipamentos.FindAsync(id);

            if (existingEquipamento == null)
                throw new KeyNotFoundException($"Equipamento com o ID {id} não encontrado");

            existingEquipamento.Name = equipamento.Name;
            existingEquipamento.Quantity = equipamento.Quantity;
            existingEquipamento.TipoEquipamento = equipamento.TipoEquipamento;

            await _context.SaveChangesAsync();
            return existingEquipamento;
        }
        public async Task<bool> DeleteEquipamentosAsync(int id)
        {
            var equipamento = await _context.Equipamentos.FindAsync(id);

            if (equipamento == null)
                return false;

            _context.Equipamentos.Remove(equipamento);
            await _context.SaveChangesAsync();
            return true;
        }

        
        
    }
}
