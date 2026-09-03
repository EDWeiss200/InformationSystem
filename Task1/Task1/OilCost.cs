using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class OilCost
    {
        public string OilType { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }

        public OilCost(string oilType, DateTime date, double cost) 
        {
            OilType = oilType;
            Date = date;
            Cost = cost;
        }

    }
}
