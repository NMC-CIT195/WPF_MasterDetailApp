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
        #region FIELDS

        ProductWindowViewModel _productWindowViewModel;

        #endregion

        #region METHODS (pass events to view model)

        private void Button_Quit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            _productWindowViewModel.DeleteCharacter();
        }

        private void RadioButton_LastNameSort_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                _productWindowViewModel.SortList(ProductWindowViewModel.ProductListSort.LastName);
            }
        }

        private void RadioButton_AgeSort_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                _productWindowViewModel.SortList(ProductWindowViewModel.ProductListSort.Age);
            }
        }

        private void RadioButton_AverageAnnualGrossSort_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                _productWindowViewModel.SortList(ProductWindowViewModel.ProductListSort.AverageAnnualGross);
            }
        }

        private void ComboBox_LastNameFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded)
            {
                ComboBox comboBox = sender as ComboBox;
                string lastName = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                _productWindowViewModel.FilterListLastName(lastName);
            }

        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Search.Text != "")
            {
               _productWindowViewModel.SearchListLastName(TextBox_Search.Text);
            }
        }

        #endregion

        #region CONSTRUCTORS

        public ProductWindowView(ProductWindowViewModel productViewModel)
        {
            _productWindowViewModel = productViewModel;

            InitializeComponent();

            DataContext = _productWindowViewModel;
        }

        #endregion
    }
}
