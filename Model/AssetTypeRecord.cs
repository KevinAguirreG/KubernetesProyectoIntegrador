using Microsip_Rentas.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsip_Rentas.Model
{
    public class AssetTypeRecord: ViewModelBase
    {

        private int _id;
        public int Id 
        { 
            get 
            { 
                return _id; 
            } 
            set 
            { 
                _id = value;
                OnPropertyChanged("Id");
            } 
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        private string _abreviationName;
        public string AbreviationName
        {
            get
            {
                return _abreviationName;
            }
            set
            {
                _abreviationName = value;
                OnPropertyChanged("AbreviationName");
            }
        }
        private decimal _price; 
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        private ObservableCollection<AssetTypeRecord> _assetTypeRecords;
        public ObservableCollection<AssetTypeRecord> AssetTypeRecords
        {
            get
            {
                return _assetTypeRecords;
            }
            set
            {
                _assetTypeRecords = value;
                OnPropertyChanged("AssetTypeRecords");
            }
        }

        private void AssetTypeModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("AssetTypeRecords");
        }
    }
}
