using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentTest.ViewModels.Entities
{
    public class TestCaseViewModel : BaseViewModel
    {
        public TestCase TestCase { get; protected set; }

        private ObservableCollection<TestStepViewModel> _testStepCollection;
        public ObservableCollection<TestStepViewModel> TestStepCollection
        {
            get { return _testStepCollection; }
            set
            {
                if (_testStepCollection != value)
                {
                    _testStepCollection = value;
                    RaisePropertyChanged(() => TestStepCollection);
                }
            }
        }
        
        public string Name
        {
            get { return TestCase.Name; }
            set
            {
                if (TestCase.Name != value)
                {
                    TestCase.Name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }
        private bool _isSelected;

        public bool IsSelected
        {
            get { return this._isSelected; }

            set
            {
                if (this._isSelected != value)
                {
                    this._isSelected = value;

                    SelectedNode = this.TestCase;

                    RaisePropertyChanged(() => SelectedNode);
                }
            }
        }
        private void OnCheckChanged()
        {
            foreach (TestStepViewModel testStepViewModel in TestStepCollection)
            {
                testStepViewModel.IsSelected = IsSelected;
            }
        }
        public TestCaseViewModel(TestCase testCase)
        {
            this.TestCase = testCase;
            TestStepCollection = new ObservableCollection<TestStepViewModel>();
            foreach (TestStep step in TestCase.TestSteps)
            {
                TestStepCollection.Add(new TestStepViewModel(step));
            }
        }
    }
}
