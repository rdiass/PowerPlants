using PowerPlants.Business.Models;
using System.Collections.Generic;

namespace PowerPlants.Business.Intefaces
{
    public interface IProductionService
    {
        IEnumerable<Production> GetPlan(PayLoad payLoad);        
    }
}