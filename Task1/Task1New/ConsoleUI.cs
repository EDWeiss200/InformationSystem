using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class ConsoleUI
    {


        public int ShowAndGetAction()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Вывести список всех объектов типа OilCost");
                Console.WriteLine("2. Добавить объект OilCost");
                Console.WriteLine("3. Выход");
                Console.Write("Ваш выбор: ");

                string actionStr = Console.ReadLine() ?? string.Empty; ;
                if (int.TryParse(actionStr, out int action))
                {
                    return action;
                }

                Console.WriteLine("Введите корректное целое число!");
                Console.ReadLine();
            }
        }

        public string GetPathFile()
        {
            Console.Write("Введите путь к файлу или используйте базовый (C:/Users/Григорий/Desktop/text.txt) пустым вводом: ");
            string path = Console.ReadLine() ?? string.Empty; ;
            if (path == string.Empty)
            {
                return "C:\\Users\\Григорий\\Desktop\\text.txt";
            }
            return path;
        }

        public void PrintOils(List<OilCost> listOils)
        {
            foreach(OilCost oil in listOils)
            {
                Console.WriteLine(oil.ToString()+"\n");
            }
            Console.ReadLine();
        }

        public string GetStringForOil()
        {
            Console.WriteLine("Введите строку с данными для нового объекта класса OilCost");
            Console.WriteLine("=======================================");
            Console.WriteLine("ФОРМАТ строки для OilCost:");
            Console.WriteLine("OIL 'ТИП-ТОПЛИВА' ДАТА:yyyy.MM.dd ЦЕНА");
            Console.WriteLine("=======================================");
            Console.WriteLine("ФОРМАТ строки для OptFuelPrice:");
            Console.WriteLine("OPTOIL 'ТИП-ТОПЛИВА' ДАТА:yyyy.MM.dd ЦЕНА-ТОПЛИВА ЦЕНА-ДОСТАВКИ ДНЕЙ-ДОСТАВКИ");
            Console.WriteLine("=======================================");
            Console.WriteLine("ФОРМАТ строки для StationFuelPrice:");
            Console.WriteLine("STATIONOIL 'ТИП-ТОПЛИВА' ДАТА:yyyy.MM.dd ЦЕНА ЗАПРАВКА НАЛИЧИЕ-СКИДКИ(bool)");
            Console.WriteLine("======================================="+"\n");
            Console.WriteLine("Ваша строка:");
            string line = Console.ReadLine() ?? string.Empty; ;
            return line;

        }

        public void ExceptionPrint(Exception e)
        {
            Console.WriteLine(e.Message);

            if (e.InnerException != null)
            {
                Console.WriteLine($"Причина: {e.InnerException.Message}");
            }
            Console.ReadLine();
        }

        public void UncorrectAction()
        {
            Console.WriteLine("Варианта с таким номером нет в списке.");
            Console.ReadLine();
        }
    }
}
