using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentTest.ViewModels.Entities
{
    public class TestCase
    {
        public TestCase(string name)
        {
            this.Name = name;
            this.TestSteps = this.SetDummyTestSteps();
        }

        public TestCase()
        {
        }

        private List<TestStep> SetDummyTestSteps()
        {
            List<TestStep> steps = new List<TestStep>();
            for (int i = 0; i < 4; i++)
            {
                TestStep tc = new TestStep("Step " + i +1);
                steps.Add(tc);
            }

            return steps;
        }

        public string Name { get; set; }

        public List<TestStep> TestSteps { get; set; }
    }
}
