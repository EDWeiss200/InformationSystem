using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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


            var(Oils,Stations) = Upload(path);
            foreach (OilCost oil in Oils)
            {
                Console.WriteLine($"Тип топлива {oil.OilType}");
                Console.WriteLine($"Дата {oil.Date:yyyy.MM.dd}");
                Console.WriteLine($"Стоимость {oil.Cost}");
            }

            foreach (AZS azs in Stations)
            {
                Console.WriteLine($"X {azs.X}");
                Console.WriteLine($"Y {azs.Y}");
                Console.WriteLine($"Z {azs.Z}");
                Console.WriteLine($"Имя {azs.Name}");

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

        static public (List<OilCost> Oils, List<AZS> Stations) Upload(string path)
        {
            List<OilCost> listOil = new List<OilCost>();
            List<AZS> listAZS = new List<AZS>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;


                while ((line = reader.ReadLine()) != "")
                {
                    if (line.Split(' ')[0] == "OIL")
                    {
                        OilCost oil = GenerateOil(line);
                        listOil.Add(oil);
                    }
                    else
                    {
                        AZS azs = GenerateAZS(line);
                        listAZS.Add(azs);
                    }
                    
                }
            }

            return (listOil,listAZS);
        }


    }
}
