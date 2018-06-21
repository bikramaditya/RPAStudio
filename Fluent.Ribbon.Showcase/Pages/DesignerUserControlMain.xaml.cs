using FluentTest.ViewModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FluentTest.Pages
{
    /// <summary>
    /// Interaction logic for DesignerUserControlMain.xaml
    /// </summary>
    public partial class DesignerUserControlMain : UserControl
    {
        private object BeingEdited;
        private Type TypeBeingEdited;

        public DesignerUserControlMain()
        {
            this.InitializeComponent();
        }

        private void TestCaseTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            FluentTest.ViewModels.MainViewModel dataModel = (FluentTest.ViewModels.MainViewModel)this.DataContext;
            dataModel.ViewModel.SelectedNode = this.TestCaseTreeView.SelectedItem;

            //this.edit_button.IsEnabled = true;
        }
    }
}
