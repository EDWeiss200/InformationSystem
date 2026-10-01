using System.Globalization;


namespace Task1
{
    public class UnitTest1
    {
        [Fact]
        public void GenerateList1_True()
        {
            string data = """
            A--|>B
            C--|>B
            E--|>A
            D--|>C
            F--|>C
            A==>F
            """;


            Dictionary<string, List<List<string>>> etalon = new Dictionary<string, List<List<string>>>();


            etalon.Add("B", new List<List<string>>() { new List<string>() { "A", "C" }, new List<string>()});
            etalon.Add("A", new List<List<string>>() { new List<string>() { "E" }, new List<string>() { "F" } });
            etalon.Add("C", new List<List<string>>() { new List<string>() { "D", "E"}, new List<string>() });
            etalon.Add("E", new List<List<string>>() { new List<string>(), new List<string>()});
            etalon.Add("D", new List<List<string>>() { new List<string>(), new List<string>() });
            etalon.Add("F", new List<List<string>>() { new List<string>(), new List<string>() });


            Dictionary<string, List<List<string>>> result = Program.GenerateAdjacancyList(data);

            Assert.Equal(etalon, result);
        }

        [Fact]
        public void GenerateList2_True()
        {
            string data = """
            B--|>A
            C--|>A
            E--|>C
            D--|>B
            F--|>B
            F==>E
            D==>C
            """;


            Dictionary<string, List<List<string>>> etalon = new Dictionary<string, List<List<string>>>();


            etalon.Add("A", new List<List<string>>() { new List<string>() { "B", "C" }, new List<string>() });
            etalon.Add("B", new List<List<string>>() { new List<string>() { "D", "F" }, new List<string>() { "F" } });
            etalon.Add("C", new List<List<string>>() { new List<string>() { "E" }, new List<string>() });
            etalon.Add("D", new List<List<string>>() { new List<string>(), new List<string>() { "C" } });
            etalon.Add("F", new List<List<string>>() { new List<string>(), new List<string>() { "E" } });



            Dictionary<string, List<List<string>>> result = Program.GenerateAdjacancyList(data);

            Assert.Equal(etalon, result);
        }


        [Fact]
        public void GenerateList_FormatExceprion1()
        {
            string data = """
            A--|>B
            D--|>D
            E--|>C
            F--|>E
            F==|>B
            F==>E
            D==>C
            """;

            Dictionary<string, List<List<string>>> result = Program.GenerateAdjacancyList(data);
            Assert.Throws<FormatException>(() => result);
        }


        public void GenerateList_FormatExceprion_EmptyString()
        {
            string data = """
            B--|>A
            C--|>A
            E--|>C

            D--|>B
            F--|>B
            F==>E
            D==>C
            """;

            Dictionary<string, List<List<string>>> result = Program.GenerateAdjacancyList(data);
            Assert.Throws<FormatException>(() => result);
        }


        [Fact]
        public void GenerateList_ArgumentExceprion()
        {
            string data = null;

            Dictionary<string, List<List<string>>> result = Program.GenerateAdjacancyList(data);
            Assert.Throws<ArgumentException>(() => result);
        }
    }
}