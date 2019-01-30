using WPF_MasterDetailApp.Models;
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

namespace WPF_MasterDetailApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ProductWindowView : Window
    {
        ProductWindowViewModel _productWindowViewModel;

        public ProductWindowView(ProductWindowViewModel productViewModel)
        {
            _productWindowViewModel = productViewModel;

            InitializeComponent();

            DataContext = _productWindowViewModel;
        }

        private void Button_Quit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            _productWindowViewModel.DeleteCharacter();
        }

        private void RadioButton_LastNameSort_Checked(object sender, RoutedEventArgs e)
        {
            _productWindowViewModel.SortList(ProductWindowViewModel.ProductListSort.LastName);            
        }

        private void RadioButton_AgeSort_Checked(object sender, RoutedEventArgs e)
        {
            _productWindowViewModel.SortList(ProductWindowViewModel.ProductListSort.Age);
        }
    }
}
