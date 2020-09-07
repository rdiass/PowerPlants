using System.Collections.Generic;
using System.Linq;
using PowerPlants.Business.Intefaces;
using PowerPlants.Business.Models;

namespace PowerPlants.Business.Services
{
    public class ProductionService : IProductionService
    {
        public IEnumerable<Production> GetPlan(PayLoad payLoad)
        {
            var productionListWithValues = GenerateValues(payLoad);
            var finalProductionList = new List<Production>();
            double totalEnergyNecessery = payLoad.Load;
            
            foreach (var powerPlant in productionListWithValues)
            {
                while (totalEnergyNecessery > 0)
                {
                    if (powerPlant.MinEnergy < totalEnergyNecessery && powerPlant.TotalEnergy < totalEnergyNecessery)
                    {
                        totalEnergyNecessery = totalEnergyNecessery - powerPlant.TotalEnergy;
                        finalProductionList.Add(powerPlant);
                        break;
                    }

                    if (powerPlant.MinEnergy < totalEnergyNecessery && powerPlant.TotalEnergy > totalEnergyNecessery)
                    {
                        powerPlant.TotalEnergy = totalEnergyNecessery;
                        totalEnergyNecessery = totalEnergyNecessery - powerPlant.TotalEnergy;
                        finalProductionList.Add(powerPlant);
                        break;
                    }

                    break;
                }

                var exist = finalProductionList.Where(a => a.NamePowerPlant == powerPlant.NamePowerPlant).Any();

                if(!exist)
                {
                    powerPlant.TotalEnergy = 0;
                    finalProductionList.Add(powerPlant);
                }
            }

            var powerPlantsOn = finalProductionList.Where(a => a.TotalEnergy > 0).OrderBy(a => a.PricePerUnit).ToList();
            var powerPlantsOff = finalProductionList.Except(powerPlantsOn);
            powerPlantsOn.AddRange(powerPlantsOff);

            var sum = powerPlantsOn.Sum(a => a.TotalEnergy);

            return powerPlantsOn;
        }

        private IEnumerable<Production> GenerateValues(PayLoad payLoad)
        {
            var productionList = new List<Production>();

            foreach (var powerPlant in payLoad.PowerPlants)
            {
                double unitEfficiency = 1 / powerPlant.Efficiency;
                double priceForOneUnit = 0;
                double totalEnergy = powerPlant.Pmax;
                double totalPrice;

                if (powerPlant.Type == "gasfired")
                {
                    totalEnergy = powerPlant.Pmax - powerPlant.Pmin;
                    priceForOneUnit = unitEfficiency * payLoad.Fuels.Gas;
                }

                if (powerPlant.Type == "turbojet")
                {
                    priceForOneUnit = unitEfficiency * payLoad.Fuels.Kerosine;
                }

                if (powerPlant.Type == "windturbine")
                {
                    if (payLoad.Fuels.Wind == 0)
                    {
                        totalEnergy = 0;
                    }
                }

                totalPrice = priceForOneUnit * powerPlant.Pmax;

                productionList.Add(new Production
                {
                    NamePowerPlant = powerPlant.Name,
                    PricePerUnit = priceForOneUnit,
                    MinEnergy = powerPlant.Pmin,
                    TotalEnergy = totalEnergy,
                    TotalPrice = totalPrice
                });
            }

            return productionList.OrderBy(a => a.PricePerUnit).ToList();
        }
    }
}