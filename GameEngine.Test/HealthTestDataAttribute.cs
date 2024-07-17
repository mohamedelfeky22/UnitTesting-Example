using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace GameEngine.Test
{
    public class HealthTestDataAttribute : DataAttribute
    {
        //First Way 
        //public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        //{
        //    yield return new object[] { 0, 100 };
        //    yield return new object[] { 1, 99 };
        //    yield return new object[] { 50, 50 };
        //    yield return new object[] { 101, 1 };
        //}

        //Second Way ,We can combine External Data with Custom attributes 
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string[] data = File.ReadAllLines("TestData.csv");
            var testCases = new List<object[]>();
            foreach (string line in data)
            {
                IEnumerable<int> values = line.Split(',').Select(int.Parse);
                object[] testCase = values.Cast<object>().ToArray();
                testCases.Add(testCase);
            }
            return testCases;

        }
    }
}
