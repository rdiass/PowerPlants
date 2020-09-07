namespace PowerPlants.Business.Models
{
    public class Production
    {
        public string NamePowerPlant { get; set; }
        public double PricePerUnit { get; set; }
        public double TotalEnergy { get; set; }
        public double TotalPrice { get; set; }

        public double MinEnergy { get; set; }
        public string PowerPlantType { get; set; }
    }
}
