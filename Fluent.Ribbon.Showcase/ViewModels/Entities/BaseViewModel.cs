using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FluentTest.ViewModels.Entities
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Events

        private static BaseViewModel _BaseViewModel = null;

        public event PropertyChangedEventHandler PropertyChanged;

        private static ObservableCollection<TestSuitViewModel> _TestSuitCollection;

        internal static BaseViewModel GetInstance()
        {
            if (_BaseViewModel == null)
            {
                if (_TestSuitCollection == null)
                {
                    _TestSuitCollection = new ObservableCollection<TestSuitViewModel>();

                    _TestSuitCollection.Add(new TestSuitViewModel("Suit 1"));
                    _TestSuitCollection.Add(new TestSuitViewModel("Suit 2"));
                    _TestSuitCollection.Add(new TestSuitViewModel("Suit 3"));
                }
                if (_SelectedNode == null)
                {
                    _SelectedNode = new TestCase("Unselected");
                }

                _BaseViewModel = new BaseViewModel();
            }
            return _BaseViewModel;
        }

        public ObservableCollection<TestSuitViewModel> TestSuitCollection
        {
            get { return _TestSuitCollection; }
            set
            {
                if (_TestSuitCollection != value)
                {
                    _TestSuitCollection = value;
                    RaisePropertyChanged(() => TestSuitCollection);
                }
            }
        }

        private static object _SelectedNode;

        public object SelectedNode
        {
            get { return _SelectedNode; }

            set
            {
                if (_SelectedNode != value)
                {
                    _SelectedNode = value;
                    RaisePropertyChanged(() => SelectedNode);
                }
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Get name of property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetPropertyName<T>(Expression<Func<T>> e)
        {
            var member = (MemberExpression)e.Body;
            return member.Member.Name;
        }
        /// <summary>
        /// Raise when property value propertychanged or override propertychage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpression"></param>
        protected virtual void RaisePropertyChanged<T>
            (Expression<Func<T>> propertyExpression)
        {
            RaisePropertyChanged(GetPropertyName(propertyExpression));
        }
        /// <summary>
        /// Raise when property value propertychanged
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}