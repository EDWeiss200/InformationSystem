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
    }
}