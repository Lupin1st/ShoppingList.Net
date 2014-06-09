using System.Collections.ObjectModel;
using System.Diagnostics;
using Cirrious.MvvmCross.ViewModels;

namespace ShoppingList.Core.Model {
    public class DataList : MvxNotifyPropertyChanged {
        private string _name;
        private ObservableCollection<DataProduct> _products;

        public string Name {
            get { return _name; }
            set {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public ObservableCollection<DataProduct> Products {
            get { return _products; }
            set {
                _products = value;
                RaisePropertyChanged(() => Products);
            }
        }
    }
}
