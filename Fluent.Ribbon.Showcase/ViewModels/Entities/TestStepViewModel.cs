namespace FluentTest.ViewModels.Entities
{
    public class TestStepViewModel : BaseViewModel
    {
        public TestStep TestStep { get; protected set; }

        public string Name
        {
            get { return TestStep.Name; }

            set
            {
                if (TestStep.Name != value)
                {
                    TestStep.Name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }

        private bool _isChecked;

        public bool IsSelected
        {
            get { return _isChecked; }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    RaisePropertyChanged(() => SelectedNode);
                }
            }
        }

        public TestStepViewModel(TestStep step)
        {
            this.TestStep = step;
            IsSelected = false;
        }
    }
}
