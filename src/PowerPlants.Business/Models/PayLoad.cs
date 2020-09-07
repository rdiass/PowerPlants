using System.Collections.Generic;

namespace PowerPlants.Business.Models
{
    public class PayLoad
    {
        public int Load { get; set; }        
        public Fuels Fuels { get; set; }
        public IEnumerable<PowerPlant> PowerPlants { get; set; }
    }
}
