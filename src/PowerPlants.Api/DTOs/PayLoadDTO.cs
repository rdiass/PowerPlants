using System.Collections.Generic;

namespace PowerPlants.Api.DTOs
{
    public class PayLoadDTO
    {
        public int Load { get; set; }        
        public FuelsDTO Fuels { get; set; }
        public IEnumerable<PowerPlantDTO> PowerPlants { get; set; }
    }
}
