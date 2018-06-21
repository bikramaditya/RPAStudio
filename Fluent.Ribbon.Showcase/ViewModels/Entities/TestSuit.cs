using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentTest.ViewModels.Entities
{
    public class TestSuit
    {
        public TestSuit(string name)
        {
            this.Name = name;
            this.TestCases = this.SetDummyTestCases();
        }

        private List<TestCase> SetDummyTestCases()
        {
            List<TestCase> cases = new List<TestCase>();
            for (int i = 0; i < 4; i++)
            {
                TestCase tc = new TestCase("Sequence " + i+1);
                cases.Add(tc);
            }

            return cases;
        }

        public string Name { get; set; }

        public List<TestCase> TestCases { get; set; }
    }
}
