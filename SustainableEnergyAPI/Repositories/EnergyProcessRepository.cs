using MongoDB.Driver;
using SustainableEnergyAPI.Data;
using SustainableEnergyAPI.Models;

namespace SustainableEnergyAPI.Repositories
{
    public class EnergyProcessRepository : IEnergyProcessRepository
    {
        private readonly IMongoCollection<EnergyProcess> _collection;

        // Construtor ajustado para usar o MongoDbContext
        public EnergyProcessRepository(MongoDbContext context)
        {
            // Usando o método GetCollection do MongoDbContext
            _collection = context.GetCollection<EnergyProcess>("EnergyProcesses");
        }

        public IEnumerable<EnergyProcess> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public EnergyProcess GetById(string id)
        {
            return _collection.Find(process => process.Id == id).FirstOrDefault();
        }

        public void Create(EnergyProcess process)
        {
            _collection.InsertOne(process);
        }

        public void Update(EnergyProcess process)
        {
            _collection.ReplaceOne(p => p.Id == process.Id, process);
        }

        public void Delete(string id)
        {
            _collection.DeleteOne(process => process.Id == id);
        }
    }
}
