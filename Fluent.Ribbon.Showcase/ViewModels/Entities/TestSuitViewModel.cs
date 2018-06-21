using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentTest.ViewModels.Entities
{
    public class TestSuitViewModel : BaseViewModel
    {
        public bool IsDirty { get; set; }

        private string _SuitName = "";
        public string Name
        {
            get { return _SuitName; }
            set
            {
                if (_SuitName != value)
                {
                    _SuitName = value;
                    IsDirty = true;
                    RaisePropertyChanged(() => Name);
                }
            }
        }

        private ObservableCollection<TestCaseViewModel> _testCaseCollection;
        public ObservableCollection<TestCaseViewModel> TestCaseCollection
        {
            get { return _testCaseCollection; }
            set
            {
                if (_testCaseCollection != value)
                {
                    _testCaseCollection = value;
                    RaisePropertyChanged(() => TestCaseCollection);
                }
            }
        }
        public TestSuitViewModel(string name)
        {
            Name = name;
            TestCaseCollection = new ObservableCollection<TestCaseViewModel>();
            List<TestCase> testCaseList = GetTestCaseList();
            foreach (TestCase testCase in testCaseList)
            {
                TestCaseCollection.Add(new TestCaseViewModel(testCase));
            }
        }

        #region Methods
        List<TestStep> GetTestStepList()
        {
            List<TestStep> testStepList = new List<TestStep>();
            testStepList.Add(new TestStep() { Name = "Hiren" });
            testStepList.Add(new TestStep() { Name = "Imran" });
            testStepList.Add(new TestStep() { Name = "Shivpal" });
            testStepList.Add(new TestStep() { Name = "Prabhat" });
            testStepList.Add(new TestStep() { Name = "Sandip" });
            testStepList.Add(new TestStep() { Name = "Chetan" });
            testStepList.Add(new TestStep() { Name = "Jayesh" });
            testStepList.Add(new TestStep() { Name = "Bhavik" });
            testStepList.Add(new TestStep() { Name = "Amit" });
            testStepList.Add(new TestStep() { Name = "Brijesh" });
            return testStepList;
        }

        List<TestCase> GetTestCaseList()
        {
            List<TestStep> testStepList = GetTestStepList();
            List<TestCase> testCaseList = new List<TestCase>();
            testCaseList.Add(new TestCase()
            {
                Name = "Mocrosoft.Net",
                TestSteps = testStepList.Take(3).ToList()
            });
            testCaseList.Add(new TestCase()
            {
                Name = "Open Source",
                TestSteps = testStepList.Skip(3).Take(3).ToList()
            });
            testCaseList.Add(new TestCase()
            {
                Name = "Other",
                TestSteps = testStepList.Skip(6).Take(4).ToList()
            });
            return testCaseList;
        }
        #endregion
    }
}
