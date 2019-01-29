using WPF_MasterDetailApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_MasterDetailApp.Models
{
    public class MainWindowViewModel
    {
        #region COMMANDS


        #endregion

        #region ENUMS



        #endregion

        #region FIELDS

        private TalentAgency _talentAgency;
        private ObservableCollection<Character> _characters;
        private Character _selectedCharacter;

        #endregion

        #region PROPERTIES

        public TalentAgency TalentAgency
        {
            get { return _talentAgency; }
            set { _talentAgency = value; }
        }

        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set { _characters = value; }
        }

        public Character SelectedCharacter
        {
            get { return _selectedCharacter; }
            set { _selectedCharacter = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public MainWindowViewModel()
        {

        }

        #endregion

        #region METHODS


        #endregion

        #region EVENTS


        #endregion


    }
}
