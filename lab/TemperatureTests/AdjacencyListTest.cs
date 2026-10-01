using lab;

namespace TemperatureTests
{
    public class AdjacencyListTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("A-->B\nC-->B\nE-->A\nDL-->C\nF-  ->C\nA-<fsf>F")]
        public void AdjacencyList_CreatesCorrectly(string? input)
        {
            Dictionary<char, List<string[]>> answer = new Dictionary<char, List<string[]>>
            {
                { 'A', new List<string[]> { new string[2] { "B", "inherit" }, new string[2] { "E" , "aggregation"}} },
                { 'C', new List<string[]> { new string[2] { "B" , "inherit" } } },
                { 'E', new List<string[]> { new string[2] { "A" , "inherit" } } },
                { 'D', new List<string[]> { new string[2] { "C" , "inherit" } } },
                { 'F', new List<string[]> { new string[2] { "C" , "inherit" } } }
            };
            Assert.Equal(answer, ParseGraph.AdjacencyList(input));
        }
    }
}
