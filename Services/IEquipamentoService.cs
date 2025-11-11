using Estoquismo.Entities;

namespace Estoquismo.Services
{
    public interface IEquipamentoService
    {

        Task<IEnumerable<Equipamentos>> GetAllEquipamentosAsync();
        Task<IEnumerable<Equipamentos>> GetEquipamentosByIdAsync(int id);
        Task<IEnumerable<Equipamentos>> GetEquipamentosByNameAsync(string name);
        Task<IEnumerable<Equipamentos>> GetEquipamentosByTypeAsync(string type);
        Task<IEnumerable<Equipamentos>> GetEquipamentosByMonthAsync(int month, int year);
        Task<IEnumerable<Equipamentos>> GetEquipamentosByNameAndMonthAsync(string name, int month, int year);
        Task<IEnumerable<Equipamentos>> GetEquipamentosByNameMonthAndTypeAsync
            (string name, int month, int year, TipoEquipamento tipo);

        Task<Equipamentos> CreateEquipamentosAsync(Equipamentos equipamento);
        Task<Equipamentos> UpdateEquipamentosAsync(int id, Equipamentos equipamento);
        Task<bool> DeleteEquipamentosAsync(int id);
    }
}
