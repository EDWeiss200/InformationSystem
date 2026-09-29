namespace Task1
{
    public class Program
    {
        private static readonly ConsoleUI ui = new ConsoleUI();
        private static readonly FileHandler fileHandler = new FileHandler();
        private static readonly FuelParser fuelParser = new FuelParser();

        static void Main(string[] args)
        {
            FuelRepository fuelRepository = InitRepository();

            bool isRunning = true;
            while (isRunning)
            {
                try
                {
                    int action = ui.ShowAndGetAction();

                    switch (action)
                    {
                        case 1:
                            ui.PrintOils(fuelRepository.GetAllOils());
                            break;

                        case 2:
                            AddNewOil(fuelRepository);
                            break;

                        case 3:
                            isRunning = false;
                            break;

                        default:
                            ui.UncorrectAction();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    ui.ExceptionPrint(ex);
                }
            }
        }

        private static FuelRepository InitRepository()
        {
            while (true)
            {
                try
                {
                    string path = ui.GetPathFile();
                    List<string> lines = fileHandler.ReadLines(path);
                    var listOils = lines.Select(line => fuelParser.ParseLine(line)).ToList();
                    return new FuelRepository(listOils);
                }
                catch (Exception ex)
                {
                    ui.ExceptionPrint(ex);
                }
            }
        }

        private static void AddNewOil(FuelRepository repository)
        {
            string line = ui.GetStringForOil();
            OilCost oil = fuelParser.ParseLine(line);
            repository.AddOil(oil);
        }
    }
}