using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string input_data = Console.ReadLine();
            string[] input_data_list = input_data.Split(' ');
            string OilType = input_data_list[0].Trim('"');
            DateTime dt = DateTime.ParseExact(input_data_list[1], "yyyy.mm.dd", null);
            double cost = Double.Parse(input_data_list[2]);

            OilCost oilcost = new OilCost(OilType, dt, cost);

            Console.WriteLine($"Тип топлива {oilcost.OilType}");
            Console.WriteLine($"Дата {oilcost.Date}");
            Console.WriteLine($"Стоимость {oilcost.Cost}");

        }
    }
}
