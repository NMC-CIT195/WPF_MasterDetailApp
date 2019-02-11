﻿using WPF_MasterDetailApp.Models;
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
using Microsoft.Win32;
using System.IO;

namespace WPF_MasterDetailApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ProductAddWindowView : Window
    {
        string _errorMessage;
        Product _product;

        public ProductAddWindowView(Product product)
        {
            _product = product;
            InitializeComponent();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            _product = null;
            Close();
        }

        private void Button_AddImage_Click(object sender, RoutedEventArgs e)
        {
            //string imageFolderPath = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"Images\";
            string imageFolderPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\Images\";

            OpenFileDialog addImageDialog = new OpenFileDialog();

            addImageDialog.Title = "Select an image";
            addImageDialog.Filter =
                "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";

            if (addImageDialog.ShowDialog() == true)
            {
                //
                // update image on window
                //
                Image_ProductImage.Source = new BitmapImage(new Uri(addImageDialog.FileName));

                //
                // create image folder if it does not exist
                //
                if (!Directory.Exists(imageFolderPath))
                {
                    Directory.CreateDirectory(imageFolderPath);
                }

                //
                // get image file name and path
                //
                string fileName = System.IO.Path.GetFileName(addImageDialog.FileName);
                string filePath = imageFolderPath + fileName;


                System.IO.File.Copy(addImageDialog.FileName, filePath, true);

                _product.ImageFileName = fileName;
            }
        }

        private bool SaveImageFileToFolder()
        {
            bool fileSavedToFolder = false;


            return fileSavedToFolder;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidateForm())
            {
                _product.FirstName = TextBox_FirstName.Text;
                _product.LastName = TextBox_LastName.Text;
                _product.Age = int.Parse(TextBox_Age.Text);
                _product.Gender = (Product.GenderType)Enum.Parse(typeof(Product.GenderType), TextBox_Gender.Text);
                _product.HireDate = DateTime.Parse(TextBox_HireDate.Text);
                _product.AverageAnnualGross = double.Parse(TextBox_AnnualGross.Text);
                _product.Description = TextBox_Description.Text;

                Close();
            }
            else
            {
                MessageBox.Show(_errorMessage);
                _errorMessage = "";
            }
        }

        private bool IsValidateForm()
        {
            bool isValidForm = true;

            //
            // validate required fields
            //
            if (TextBox_FirstName.Text == "") { _errorMessage += "The First Name field cannot be empty.\n"; isValidForm = false; }
            if (TextBox_LastName.Text == "") { _errorMessage += "The Last Name field cannot be empty.\n"; isValidForm = false; }
            if (TextBox_Age.Text == "") { _errorMessage += "The Age field cannot be empty.\n"; isValidForm = false; }
            if (TextBox_Gender.Text == "") { _errorMessage += "The Gender Name field cannot be empty.\n"; isValidForm = false; }
            if (TextBox_HireDate.Text == "") { _errorMessage += "The Hire Date field cannot be empty.\n"; isValidForm = false; }
            if (TextBox_AnnualGross.Text == "") { _errorMessage += "The Average Annual Gross field cannot be empty.\n"; isValidForm = false; }
            if (TextBox_Description.Text == "") { _errorMessage += "The Description field cannot be empty.\n"; isValidForm = false; }

            _errorMessage += "\n";

            //
            // validate input for fields 
            //
            if (!int.TryParse(TextBox_Age.Text, out int age)) { _errorMessage += "Age must be an integer value.\n"; isValidForm = false; }
            if (!DateTime.TryParse(TextBox_HireDate.Text, out DateTime hireDate)) { _errorMessage += "Hired Date must be of the form 1/1/2000.\n"; isValidForm = false; }
            if (!double.TryParse(TextBox_AnnualGross.Text, out double annualGross)) { _errorMessage += "The annual gross must be a decimal value."; isValidForm = false; }
            if (!Enum.TryParse(TextBox_Gender.Text.ToLower(), out Product.GenderType gender)) { _errorMessage += "Gender must be male or female.\n"; isValidForm = false; }

            return isValidForm;
        }
    }
}
