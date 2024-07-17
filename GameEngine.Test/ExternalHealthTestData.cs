using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Test
{
    public class ExternalHealthTestData
    {
        public static IEnumerable<object[]> Testdata
        {
            get
            {
                string[] data = File.ReadAllLines("TestData.csv");
                var testCases= new List<object[]>();
                foreach (string line in data)
                {
                    IEnumerable<int> values = line.Split(',').Select(int.Parse);
                    object[] testCase=values.Cast<object>().ToArray();
                    testCases.Add(testCase);
                }
                return testCases;
            }
        }
    }
}
