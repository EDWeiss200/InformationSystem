using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class FuelParser
    {
        public OilCost ParseLine(string line)
        {
            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string fuelType = parts[0];

            if (parts.Length < 4)
                throw new FormatException("недостаточно данных в строке");

            try
            {
                string oilType = parts[1].Trim('"');
                DateTime dt = DateTime.ParseExact(parts[2], "yyyy.MM.dd", null);
                double cost = double.Parse(parts[3]);

                switch (fuelType)
                {
                    case "OIL":
                        return new OilCost(oilType,dt,cost);

                    case "OPTOIL":
                        return GenerateOptOil(parts, oilType, dt, cost);

                    case "STATIONOIL":
                        return GenerateStationOil(parts, oilType, dt, cost);

                    default:
                        throw new FormatException($"Неизвестный тип топлива {fuelType}");
                }

            } catch (Exception e)
            {
                throw new FormatException($"Ошибка при обработке строки {line}", e);
            }     
        } 

        private OptFuelPrice GenerateOptOil(string[] parts, string oilType, DateTime dt, double cost)
        {
                int minBatchTons = int.Parse(parts[4]);
                int deliveryDays = int.Parse(parts[5]);

                OptFuelPrice optFuelPrice = new OptFuelPrice(oilType, dt, cost, minBatchTons, deliveryDays);
                return optFuelPrice;
        }


        private StationFuelPrice GenerateStationOil(string[] parts, string oilType, DateTime dt, double cost)
        {
                string stationName = parts[4].Trim('"');
                bool hasDiscount = bool.Parse(parts[5]);

                StationFuelPrice stationFuelPrice = new StationFuelPrice(oilType, dt, cost, stationName, hasDiscount);
                return stationFuelPrice;
        }
    }
}
