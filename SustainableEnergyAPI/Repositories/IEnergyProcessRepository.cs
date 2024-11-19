using SustainableEnergyAPI.Models;

namespace SustainableEnergyAPI.Repositories
{
    public interface IEnergyProcessRepository
    {
        IEnumerable<EnergyProcess> GetAll();
        EnergyProcess GetById(string id);
        void Create(EnergyProcess process);
        void Update(EnergyProcess process);
        void Delete(string id);
    }
}