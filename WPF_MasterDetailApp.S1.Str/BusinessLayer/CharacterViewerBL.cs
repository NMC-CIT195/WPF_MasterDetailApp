using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_MasterDetailApp;
using WPF_MasterDetailApp.Models;

namespace WPF_MasterDetailApp.BusinessLayer
{
    public class CharacterViewerBL
    {
        #region ENUMS



        #endregion

        #region FIELDS

        MainWindowView _mainWindowView;
        MainWindowViewModel _mainWindowViewModel;

        #endregion

        #region PROPERTIES
        
        #endregion

        #region CONSTRUCTORS

        public CharacterViewerBL()
        {
            //
            // instantiate the viewmodel and initialize the data set
            //
            _mainWindowViewModel = new MainWindowViewModel();
            InitializeTalentAgencyData();
            InitializeCharacterData();

            //
            // instantiate and show the Main Window
            //
            _mainWindowView = new MainWindowView();
            _mainWindowView.DataContext = _mainWindowViewModel;
            _mainWindowView.Show();
        }

        #endregion

        #region METHODS

        private void InitializeTalentAgencyData()
        {
            _mainWindowViewModel.TalentAgency = new TalentAgency()
            {
                Name = "Troglodyte Talent Agency",
                Address = "465 Jurassic Lane",
                City = "Bedrock"
            };
        }

        private void InitializeCharacterData()
        {
            _mainWindowViewModel.SelectedCharacter = new Character()
            {
                Id = 1,
                FirstName = "Fred",
                LastName = "Flintstone",
                Age = 28,
                Gender = Character.GenderType.Male,
                ImageFileName = "fred_flintstone.jpg",
                Description = "Fred is the main character of the series. He's an accident-prone bronto-crane operator at the Slate Rock and Gravel Company and the head of the Flintstone household. He is quick to anger (usually over trivial matters), but is nonetheless a very loving husband and father. He's also good at bowling and is a member of the fictional Loyal Order of Water Buffaloes (Lodge No. 26), a men-only club paralleling real-life fraternities such as the Loyal Order of Moose.",
                HireDate = DateTime.Parse("03-23-1963"),
                AverageAnnualGross = 23445.85
            };
        }

        #endregion

        #region EVENTS


        #endregion

    }
}
