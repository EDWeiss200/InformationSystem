using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class FuelRepository
    {
        private List<OilCost> costList;

        public FuelRepository(List<OilCost> costList)
        {
            this.costList = costList;
        }

        public void AddOil(OilCost oil)
        {
            costList.Add(oil);
        }

        public List<OilCost> GetAllOils()
        {
            return costList;
        }
    }
}
