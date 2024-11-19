using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SustainableEnergyAPI.Models
{
    public class EnergyProcess
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }  // Tornando Id anulável

        public string Name { get; set; }
        public double Efficiency { get; set; }

        // Construtor que assegura que 'Name' não seja nulo
        public EnergyProcess(string name, double efficiency)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null.");
            Efficiency = efficiency;
        }
    }
}
