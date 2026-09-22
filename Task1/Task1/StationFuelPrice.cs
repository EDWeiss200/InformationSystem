using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class StationFuelPrice: OilCost
    {
        public string StationName { get; set; }
        public bool HasDiscount { get; set; }

        public StationFuelPrice(string oilType, DateTime date, double cost, string stationName, bool hasDiscount)
            : base(oilType, date, cost)
        {
            StationName = stationName;
            HasDiscount = hasDiscount;
        }

        public override string ToString()
        {
            return $"АЗС: {StationName} Вид топлива: {OilType} Дата: {Date:yyyy.MM.dd} Цена: {Cost} СКИДКА: {HasDiscount}";
        }
    }
}

