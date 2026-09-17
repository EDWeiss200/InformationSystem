using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class OilCost
    {
        public string OilType;
        public DateTime Date { get; set; }
        public double Cost { get; set; }

        public OilCost(string oilType, DateTime date, double cost) 
        {
            OilType = oilType;
            Date = date;
            Cost = cost;
        }

        public virtual string ToString()
        {
            return $"{OilType} на {Date:yyyy.MM.dd} {Cost} руб./л";
        }


    }
}
