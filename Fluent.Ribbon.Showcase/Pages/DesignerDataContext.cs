using FluentTest.ViewModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentTest.Pages
{
    public class DesignerDataContext
    {
        private static DesignerDataContext _self = null;
        private bool _isSelected;

        public static DesignerDataContext GetContext()
        {
            if (_self != null)
            {
                return _self;
            }
            else
            {
                return new DesignerDataContext();
            }
        }
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        private void OnPropertyChanged(string v)
        {
            //throw new NotImplementedException();
            Console.WriteLine();
        }

        public DesignerDataContext()
        {
            this.LabelName = "Bikram";
            this.TestSuits = GetAllTestSuits();
        }

        public string LabelName { get; set; }

        private TestSuit[] GetAllTestSuits()
        {
            TestSuit[] suits = new TestSuit[5];
            for (int i = 0; i < 5; i++)
            {
                suits[i] = new TestSuit("Suit " + i + 1);
            }

            return suits;
        }

        public TestSuit[] TestSuits { get; private set; }

        public TestSuit TestSuit { get; private set; }
    }
}
