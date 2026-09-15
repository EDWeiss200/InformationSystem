using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class OilTruck
    {
        
        public string DriverName { get; set; }

        public string OilType { get; set; }

        public double Capacity { get; set; }

        public OilTruck(string drivername, string oiltype, double capacity)
        {
            DriverName = drivername;
            OilType = oiltype;
            Capacity = capacity;
        }
       


    }
}
