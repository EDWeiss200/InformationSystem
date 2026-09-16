using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Task1
{
    internal class FuelTankAzs
    {
        public string AZSName { get; set; }

        public bool IsUndeground { get; set; }
         
        public int MaxCapacity {  get; set; }

        public FuelTankAzs(string azsName, bool isUndeground, int maxCapacity)
        {
            AZSName = azsName;
            IsUndeground = isUndeground;
            MaxCapacity = maxCapacity;
        }
    }
}
