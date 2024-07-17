using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Test
{
      public  class InternalHealthTestData
    {
        public static IEnumerable<object[]> Testdata
        {
            get
            {
                yield return new object[] { 0, 100 };
                yield return new object[] { 1, 99 };
                yield return new object[] { 50, 50 };
                yield return new object[] { 101, 1 };
            }
        }
    }
}
