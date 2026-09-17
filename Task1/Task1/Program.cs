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
            List<OilCost> listOil = Upload(path);
            PrintOil(listOil);

        }



        static public void PrintOil(List<OilCost> listOil)
        {
            Console.WriteLine("ВЫВОД ЦЕН НА ТОПЛИВО");
            foreach (var oil in listOil)
            {
                Console.WriteLine(oil.ToString());

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


        static public OptFuelPrice GeneratуOptOil(string input_data)
        {

            string[] input_data_list = input_data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string oilType = input_data_list[1].Trim('"');
            DateTime dt = DateTime.ParseExact(input_data_list[2], "yyyy.MM.dd", null);
            double cost = double.Parse(input_data_list[3]);

            int minBatchTons = int.Parse(input_data_list[4]);
            int deliveryDays = int.Parse(input_data_list[5]);

            OptFuelPrice optFuelPrice = new OptFuelPrice(oilType, dt, cost, minBatchTons, deliveryDays);
            return optFuelPrice;
        }


        static public StationFuelPrice GenerateStationOil(string input_data)
        {

            string[] input_data_list = input_data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string oilType = input_data_list[1].Trim('"');
            DateTime dt = DateTime.ParseExact(input_data_list[2], "yyyy.MM.dd", null);
            double cost = double.Parse(input_data_list[3]);

            string stationName = input_data_list[4].Trim('"');
            bool hasDiscount = bool.Parse(input_data_list[5]);

            StationFuelPrice stationFuelPrice = new StationFuelPrice(oilType,dt, cost, stationName,hasDiscount);
            return stationFuelPrice;
        }



        static public List<OilCost> Upload(string path)
        {
            List<OilCost> listOil = new List<OilCost>();
           

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
                    else if(line.Split(' ')[0] == "OPTOIL")
                    {
                        OptFuelPrice optFuelPrice = GeneratуOptOil(line);
                        listOil.Add(optFuelPrice);
                    }
                    else if (line.Split(' ')[0] == "STATIONOIL")
                    {
                        StationFuelPrice optFuelPrice = GenerateStationOil(line);
                        listOil.Add(optFuelPrice);
                    }

                }
            }

            return listOil;
        }


    }
}
