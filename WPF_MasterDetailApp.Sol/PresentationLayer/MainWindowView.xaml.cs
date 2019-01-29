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
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();
            DataContext = MainWindowViewModel;
        }

        private void Button_Quit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Sort_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
