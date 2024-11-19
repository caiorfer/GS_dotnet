using MongoDB.Driver;

namespace SustainableEnergyAPI.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        // Construtor que aceita uma string de conexão e o nome do banco de dados
        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        // Propriedade para acessar o banco de dados
        public IMongoDatabase Database => _database;

        // Método para obter uma coleção específica
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
