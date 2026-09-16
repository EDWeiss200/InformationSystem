using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу");
            string path = Console.ReadLine();
            var(Oils,Stations,OilTrucks,FuelTanks) = Upload(path);
            PrintOilCost(Oils);
            PrintAZS(Stations);
            PrintOilTruck(OilTrucks);
            PrintFuelTank(FuelTanks);

        }



        static public void PrintOilCost(List<OilCost> Oils)
        {
            Console.WriteLine("---Список цен на топливо---");
            foreach (OilCost oil in Oils)
            {
                Console.WriteLine($"Тип топлива: {oil.OilType}");
                Console.WriteLine($"Дата: {oil.Date:yyyy.MM.dd}");
                Console.WriteLine($"Стоимость: {oil.Cost}");
            }
        }

        static public void PrintAZS(List<AZS> Stations)
        {
            Console.WriteLine("---Список АЗС---");
            foreach (AZS azs in Stations)
            {
                Console.WriteLine($"X: {azs.X}");
                Console.WriteLine($"Y: {azs.Y}");
                Console.WriteLine($"Z: {azs.Z}");
                Console.WriteLine($"Имя: {azs.Name}");

            }
        }

        static public void PrintOilTruck(List<OilTruck> oilTrucks)
        {
            Console.WriteLine("---Список Бензовозов---");
            foreach (OilTruck oilTruck in oilTrucks)
            {
                Console.WriteLine($"Имя вордителя: {oilTruck.DriverName}");
                Console.WriteLine($"Тип топлива: {oilTruck.OilType}");
                Console.WriteLine($"Вместимость (литров): {oilTruck.Capacity}");
            }
        }

        static public void PrintFuelTank(List<FuelTankAzs> FuelTanks)
        {
            Console.WriteLine("---Список Топливных баков на АЗС---");
            foreach (FuelTankAzs fuelTank in FuelTanks)
            {
                Console.WriteLine($"Имя заправки: {fuelTank.AZSName}");
                Console.WriteLine($"Находится под землей: {fuelTank.IsUndeground}");
                Console.WriteLine($"Максимальная вместимость (литров): {fuelTank.MaxCapacity}");

            }
        }





        static public OilCost GenerateOil(string input_data)
        {

            string[] input_data_list = input_data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string OilType = input_data_list[1].Trim('"');
            DateTime dt = DateTime.ParseExact(input_data_list[2], "yyyy.MM.dd", null);
            double cost = double.Parse(input_data_list[3]);

            OilCost oilcost = new OilCost(OilType, dt, cost);
            return oilcost;
        }

        static public AZS GenerateAZS(string input_data)
        {

            string[] input_data_list = input_data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int x = int.Parse(input_data_list[1]);
            int y = int.Parse(input_data_list[2]);
            int z = int.Parse(input_data_list[3]);
            string name = input_data_list[4];

            AZS azs = new AZS(x,y,z,name);
            return azs;
        }



        static public OilTruck GenerateOilTruck(string input_data)
        {

            string[] input_data_list = input_data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string driverName = input_data_list[1].Trim('"');
            string oilType = input_data_list[2].Trim('"');
            double capacity = double.Parse(input_data_list[3]);

            OilTruck oilTruck = new OilTruck(driverName, oilType, capacity);
            return oilTruck;
        }



        static public FuelTankAzs GenerateFuelTank(string input_data)
        {

            string[] input_data_list = input_data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string azsName = input_data_list[1].Trim('"');
            bool isundeground = bool.Parse(input_data_list[2]);
            int maxCapacity = int.Parse(input_data_list[3]);

            FuelTankAzs fuelTank = new FuelTankAzs(azsName,isundeground,maxCapacity);
            return fuelTank;
        }





        static public (List<OilCost> Oils, List<AZS> Stations, List<OilTruck> OilTrucks, List<FuelTankAzs> fuelTanks) Upload(string path)
        {
            List<OilCost> listOil = new List<OilCost>();
            List<AZS> listAZS = new List<AZS>();
            List<OilTruck> listOilTruck = new List<OilTruck>();
            List<FuelTankAzs> listFuelTank = new List<FuelTankAzs>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;


                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Split(' ')[0] == "OIL")
                    {
                        OilCost oil = GenerateOil(line);
                        listOil.Add(oil);
                    }
                    else if(line.Split(' ')[0] == "OILTRUCK")
                    {
                        OilTruck oilTruck = GenerateOilTruck(line);
                        listOilTruck.Add(oilTruck);
                    }
                    else if (line.Split(' ')[0] == "FUELTANK")
                    {
                        FuelTankAzs fuelTank = GenerateFuelTank(line);
                        listFuelTank.Add(fuelTank);
                    }
                    else if (line.Split(' ')[0] == "AZS")
                    {
                        AZS azs = GenerateAZS(line);
                        listAZS.Add(azs);
                    }

                }
            }

            return (listOil,listAZS,listOilTruck,listFuelTank);
        }


    }
}
