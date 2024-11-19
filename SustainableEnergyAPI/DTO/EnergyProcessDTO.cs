namespace SustainableEnergyAPI.DTO
{
    public class EnergyProcessDTO
    {
        public string Name { get; set; }
        public double Efficiency { get; set; }

        // Construtor
        public EnergyProcessDTO(string name, double efficiency)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null.");
            Efficiency = efficiency;
        }
    }
}
