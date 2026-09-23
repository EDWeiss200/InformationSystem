using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

            ConsoleUI ui = new ConsoleUI();
            FileHandler fileHandler = new FileHandler();
            FuelParser fuelParser = new FuelParser();

            string path = ui.GetPathFile();

            List<string> lines = fileHandler.ReadLines(path);

            List<OilCost> listOils = lines.Select(
                line => fuelParser.ParseLine(line))
                .ToList();

            FuelRepository fuelRepository = new FuelRepository(listOils);


            bool flag = true;

            while (flag)
            {
                int action;
                try
                {
                    action = ui.ShowAndGetAction();
                }
                catch
                {
                    continue;
                }

                switch (action)
                {
                    case 1:
                        ui.PrintOils(fuelRepository.GetAllOils());
                        Console.ReadLine();
                        break;
                    case 2:
                        string line = ui.GetStringForOil();
                        OilCost oil = fuelParser.ParseLine(line);
                        fuelRepository.AddOil(oil);
                        Console.ReadLine();
                        break;
                    case 3:
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Варианта с таким номером нет в списке. Введите корректное число из меню");
                        Console.ReadLine();
                        break;
                }



            }


        }

    }
}
