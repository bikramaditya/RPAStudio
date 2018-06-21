namespace FluentTest.ViewModels.Entities
{
    public class TestStep
    {
        public TestStep()
        {
        }

        public TestStep(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
