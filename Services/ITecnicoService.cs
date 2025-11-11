using Estoquismo.Entities;

namespace Estoquismo.Services
{
    public interface ITecnicoService
    {

        Task<IEnumerable<Tecnicos>> GetAllTecnicosAsync();
        Task<IEnumerable<Tecnicos>> GetTecnicoByIdAsync(int id);
        Task<IEnumerable<Tecnicos>> GetTecnicoByNameAsync(string name);
        Task<IEnumerable<Tecnicos>> GetTecnicoByEmailAsync(string email);


        Task<Tecnicos> CreateTecnicoAsync(Tecnicos tecnico);
        Task<Tecnicos> UpdateTecnicoAsync(int id, Tecnicos tecnico);
        Task<bool> DeleteTecnicoAsync(int id);


    }
}
