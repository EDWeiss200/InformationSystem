using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class ConsoleUI
    {


        public int ShowAndGetAction()
        {
            Console.Clear();
            Console.WriteLine("1. Вывести список всех объектов типа OilCost");
            Console.WriteLine("2. Добавить объект OilCost");
            Console.WriteLine("3. Выход");
            Console.Write("Ваш выбор: ");
            string actionStr = Console.ReadLine();
            if (!(int.TryParse(actionStr, out int action)))
            {
                Console.WriteLine("Введите корректное целое число!");
                throw new FormatException("Введенно некторектное целое число");
            }

            return action;
        }

        public string GetPathFile()
        {
            Console.Write("Введите путь к файлу: ");
            string path = Console.ReadLine();
            return path;
        }

        public void PrintOils(List<OilCost> listOils)
        {
            foreach(OilCost oil in listOils)
            {
                Console.WriteLine(oil.ToString()+"\n");
            }
        }

        public string GetStringForOil()
        {
            Console.WriteLine("Введите строку с данными для нового объекта класса OilCost");
            Console.WriteLine("=======================================");
            Console.WriteLine("ФОРМАТ строки для OilCost:");
            Console.WriteLine("OIL 'ТИП ТОПЛИВА' ДАТА:yyyy.MM.dd ЦЕНА");
            Console.WriteLine("=======================================");
            Console.WriteLine("ФОРМАТ строки для OptFuelPrice:");
            Console.WriteLine("OPTOIL 'ТИП ТОПЛИВА' ДАТА:yyyy.MM.dd ЦЕНА");
            Console.WriteLine("=======================================");
            Console.WriteLine("ФОРМАТ строки для StationFuelPrice:");
            Console.WriteLine("STATIONOIL 'ТИП ТОПЛИВА' ДАТА:yyyy.MM.dd ЦЕНА");
            Console.WriteLine("======================================="+"\n");
            Console.WriteLine("Ваша строка:");
            string line = Console.ReadLine();
            return line;

        }
    }
}
