using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2KnowledgeCheck1
{
    internal class Construction
    {
        public List<Building> Buildings { get; } = new List<Building>();
        public void CreateApartment(Apartment? apartment = null, HighRise? highrise = null)
        {
            // Get materials
            var materialRepo = new MaterialsRepo();
            var materialsNeeded = materialRepo.GetMaterials();

            var permitRepo = new ZoningAndPermitRepo();

            if (apartment != null)
            {
                var buildingWasMade = ConstructBuilding<Apartment>(materialsNeeded, permitRepo.GetPermit(), permitRepo.ZoningApproves());
                if (buildingWasMade)
                {
                    Buildings.Add(apartment);
                }
            }

            if (highrise != null)
            {
                var buildingWasMade = ConstructBuilding<HighRise>(materialsNeeded, permitRepo.GetPermit(), permitRepo.ZoningApproves());
                if (buildingWasMade)
                {
                    Buildings.Add(highrise);
                }
            }
        }

        public bool ConstructBuilding<T>(List<string> materials, bool permit, bool zoning) where T : Building
        {
            if (permit && zoning)
            {
                foreach (var material in materials)
                {
                    if (material == "concrete")
                    {
                        // start laying foundation
                    }
                    else if (material == "Steel")
                    {
                        // Start building structure
                    }
                    // etc etc...

                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
