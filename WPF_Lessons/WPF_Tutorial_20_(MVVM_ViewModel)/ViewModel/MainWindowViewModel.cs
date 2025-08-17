using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_Tutorial_20__MVVM_ViewModel_.Model;
using WPF_Tutorial_20__MVVM_ViewModel_.MVVM;

namespace WPF_Tutorial_20__MVVM_ViewModel_.ViewModel
{
    
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }

        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem() , canExecute => selectedItem != null );
        public RelayCommand SaveCommand => new RelayCommand(execute => Save() , canExecute => canSave());

        

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();
            
        }
        private Item selectedItem;
        public Item SelectedItem
        {
            get { return selectedItem; }
            set 
            { 
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        private void AddItem()
        {
            Items.Add(new Item
            {
                Name = "Product1",
                SerialNumber = "0001",
                Quantity = 5,
            });
        }

        private void DeleteItem()
        {
            Items.Remove(selectedItem);
        }

        private void Save()
        {
            throw new NotImplementedException();
        }

        private bool canSave()
        {
            return true;
        }

        
    }
}
