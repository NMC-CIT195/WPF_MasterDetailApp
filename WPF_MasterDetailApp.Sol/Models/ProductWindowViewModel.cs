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
            Age,
            AverageAnnualGross
        }

        #endregion

        #region FIELDS

        private Company _talentAgency;
        private ObservableCollection<Character> _activeCharacters;
        private List<Character> _allCharacters;
        private Character _selectedCharacter;

        #endregion

        #region PROPERTIES

        public Company TalentAgency
        {
            get { return _talentAgency; }
            set { _talentAgency = value; }
        }

        public List<Character> AllCharacters
        {
            get { return _allCharacters; }
            set { _allCharacters = value; }
        }

        public ObservableCollection<Character> ActiveCharacters
        {
            get { return _activeCharacters; }
            set { _activeCharacters = value; }
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

        public ProductWindowViewModel(Company company, List<Character> products)
        {
            _allCharacters = products;
            _activeCharacters = new ObservableCollection<Character>(products);
            _talentAgency = company;
        }

        #endregion

        #region METHODS

        public void DeleteCharacter()
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Are you sure you want to delete {_selectedCharacter.FullName}?", "Delete Character", System.Windows.MessageBoxButton.OKCancel);

            if (messageBoxResult == MessageBoxResult.OK)
            {
                _allCharacters.Remove(_selectedCharacter);
                _activeCharacters.Remove(_selectedCharacter);
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
                    _activeCharacters = new ObservableCollection<Character>(_activeCharacters.OrderBy(c => c.LastName));
                    RaisePropertyChangedEvent("ActiveCharacters");
                    break;
                case ProductListSort.Age:
                    _activeCharacters = new ObservableCollection<Character>(_activeCharacters.OrderBy(c => c.Age));
                    RaisePropertyChangedEvent("ActiveCharacters");
                    break;
                case ProductListSort.AverageAnnualGross:
                    _activeCharacters = new ObservableCollection<Character>(_activeCharacters.OrderBy(c => c.AverageAnnualGross));
                    RaisePropertyChangedEvent("ActiveCharacters");
                    break;
                default:
                    break;
            }
        }

        public void FilterListLastName(string lastName)
        {
            if (lastName != "All Names")
            {
                _activeCharacters = new ObservableCollection<Character>(_allCharacters.Where(c => c.LastName == lastName));
            }
            else
            {
                _activeCharacters = new ObservableCollection<Character>(_allCharacters);
            }
            RaisePropertyChangedEvent("ActiveCharacters");
        }

        public void SearchListLastName(string searchTerm)
        {
            if (searchTerm != "")
            {
                _activeCharacters = new ObservableCollection<Character>(_allCharacters.Where(c => c.LastName.ToLower().Contains(searchTerm.ToLower())));
            }
            RaisePropertyChangedEvent("ActiveCharacters");
        }

        #endregion

        #region EVENTS


        #endregion


    }
}
