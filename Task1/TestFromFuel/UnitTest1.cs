using Task1;
namespace TestFromFuel

{
    public class UnitTest1
    {

        [Theory]
        [InlineData("OIL \"ДТ\" 2007.08.08 70,75")]
        [InlineData("OIL \"АИ-95\" 2021.08.08 70,75")]
        public void GenerateOilCost_ReturnTrue(string line)
        {
            FuelParser parser = new FuelParser();
            OilCost oilCost = parser.ParseLine(line);

            Assert.NotNull(oilCost);

            Assert.IsType<OilCost>(oilCost);
        }


        [Theory]
        [InlineData("OPTOIL \"ДТ\" 2020.08.08 60,75 100 314")]
        [InlineData("OPTOIL \"АИ-92\" 2025.08.08 100 150 30")]
        public void GenerateOptOil_ReturnTrue(string line)
        {
            FuelParser parser = new FuelParser();
            var oilCost = parser.ParseLine(line);

            Assert.NotNull(oilCost);

            Assert.IsType<OptFuelPrice>(oilCost);
        }

        [Theory]
        [InlineData("STATIONOIL \"АИ-95\" 2025.08.08 70,75 \"Роснефть\" false")]
        [InlineData("STATIONOIL \"ДТ\" 2020.08.08 100 \"Газпром\" true")]

        public void GenerateStationOil_ReturnTrue(string line)
        {
            FuelParser parser = new FuelParser();
            var oilCost = parser.ParseLine(line);

            Assert.NotNull(oilCost);

            Assert.IsType<StationFuelPrice>(oilCost);
        }

        [Theory]
        [InlineData("GNOM \"АИ-95\" 2025.08.08 70,75 \"Роснефть\" false")]
        [InlineData("STATIONOIL \"ДТ\" 2020.08.08 100 \"Газпром\"")]
        [InlineData("")]
        [InlineData("STATIONOIL \"ДТ\" \"Газпром\" true")]
        [InlineData("STATIONOIL \"ДТ\"")]
        public void GenerateFuelObject_ReturnFalse(string line)
        {
            FuelParser parser = new FuelParser();
            Assert.Throws<FormatException>(() => parser.ParseLine(line));
        }


        [Theory]
        [InlineData("OIL \"ДТ\" 2020-08-08 70.75")]
        [InlineData("OIL \"ДТ\" 2020.08.08 СЕМЬДЕСЯТ")]
        [InlineData("OPTOIL \"ДТ\" 2020.08.08 60.75 сто 10")]
        public void ParseLine_InvalidDataType_ThrowsFormatException(string line)
        {
            FuelParser parser = new FuelParser();
            Assert.Throws<FormatException>(() => parser.ParseLine(line));
        }


        [Fact]
        public void OilCost_ToString_ReturnsFormattedString()
        {
            var oil = new OilCost("АИ-95", new DateTime(2023, 10, 25), 55.5);

            string result = oil.ToString();

            Assert.Contains("АИ-95", result);
            Assert.Contains("2023.10.25", result);
            Assert.Contains("55,5", result);
        }


        [Fact]
        public void ReadLines_FileNotExist_ThrowsException()
        {
            var fileHandler = new FileHandler();
            string fakePath = "C:\\fake_path\\no_such_file.txt";

            var exception = Assert.Throws<Exception>(() => fileHandler.ReadLines(fakePath));
            Assert.Contains("Ошибка: Файл не найден", exception.Message);
        }

        [Fact]
        public void ReadLines_ValidFile_ReturnsLines()
        {
            var fileHandler = new FileHandler();
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllLines(tempFilePath, new[] { "Строка 1", "Строка 2" });

            try
            {
                var result = fileHandler.ReadLines(tempFilePath);

                Assert.Equal(2, result.Count);
                Assert.Equal("Строка 1", result[0]);
                Assert.Equal("Строка 2", result[1]);
            }
            finally
            {
                if (File.Exists(tempFilePath)) File.Delete(tempFilePath);
            }
        }
    }
}