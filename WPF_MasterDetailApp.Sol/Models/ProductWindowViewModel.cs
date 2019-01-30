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
    public class ProductWindowViewModel : ObservableObject
    {

        #region ENUMS

        public enum ProductListSort
        {
            LastName,
            Age
        }

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
            set
            {
                if (_selectedCharacter == value)
                {
                    return;
                }
                _selectedCharacter = value;
                RaisePropertyChangedEvent("SelectedCharacter");
            }
        }

        #endregion

        #region CONSTRUCTORS

        public ProductWindowViewModel()
        {

        }

        #endregion

        #region METHODS

        public void DeleteCharacter()
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Are you sure you want to delete {_selectedCharacter.FullName}?", "Delete Character", System.Windows.MessageBoxButton.OKCancel);

            if (messageBoxResult == MessageBoxResult.OK)
            {
                _characters.Remove(_selectedCharacter);
            }
        }

        public void EditCharacter()
        {

        }

        public void SortList(ProductListSort productListSort)
        {
            switch (productListSort)
            {
                case ProductListSort.LastName:
                    _characters = new ObservableCollection<Character>(_characters.OrderBy(c => c.LastName));
                    RaisePropertyChangedEvent("Characters");
                    break;
                case ProductListSort.Age:
                    _characters = new ObservableCollection<Character>(_characters.OrderBy(c => c.Age));
                    RaisePropertyChangedEvent("Characters");
                    break;
                default:
                    break;
            }

        }

        #endregion

        #region EVENTS


        #endregion


    }
}
